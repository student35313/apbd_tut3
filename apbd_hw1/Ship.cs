namespace apbd_hw1;

using System;
using System.Collections.Generic;
using System.Linq;

public class Ship
    {
        public double MaxSpeed { get; }
        
        public int MaxContainerCount { get; }
        
        public double MaxWeightTons { get;  }
        
        public double CurrWeightTons { get; set; }

        private List<Container> _containers = new List<Container>();

        public Ship(double maxSpeed, int maxContainerCount, double maxWeightTons)
        {
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxWeightTons = maxWeightTons;
            CurrWeightTons = 0;
        }
        
        public void AddContainer(Container container)
        {
            if (_containers.Count >= MaxContainerCount)
            {
                throw new InvalidOperationException(
                    "Cannot add container: maximum container count reached."
                );
            }
            
           double newWeight = CurrWeightTons + (container.TareWeight + container.CargoMass)/1000;
           
            if (newWeight > MaxWeightTons)
            {
                throw new InvalidOperationException(
                    $"Cannot add container: total weight {newWeight} tons exceeds the limit of {MaxWeightTons} tons."
                );
            }
            
            _containers.Add(container);
            CurrWeightTons = newWeight;
        }
        
        public void AddContainers(IEnumerable<Container> containers)
        {
            foreach (var container in containers)
            {
                AddContainer(container);
            }
        }

        // Удаление контейнера по серийному номеру
        public void RemoveContainer(string serialNumber)
        {
            var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container == null)
                throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");

            _containers.Remove(container);
        }

        // Замена контейнера (удаляет контейнер с данным серийным номером и добавляет новый)
        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            RemoveContainer(serialNumber);
            AddContainer(newContainer);
        }
        
        public void TransferContainer(string serialNumber, Ship destination)
        {
            Container container = null;

            foreach (var c in _containers)
            {
                if (c.SerialNumber == serialNumber) container = c;
            }
            
            if (container == null)
                throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
            
            _containers.Remove(container);
            destination.AddContainer(container);
        }
        
        public override string ToString()
        {
            string info = $"Ship: MaxSpeed={MaxSpeed} knots, ContainerCount={_containers.Count}/{MaxContainerCount}, TotalWeight={CurrWeightTons} tons\n";
            info += "Containers:\n";
            foreach (var container in _containers)
            {
                info += container.ToString() + "\n";
            }
            return info;
        }
        
}
