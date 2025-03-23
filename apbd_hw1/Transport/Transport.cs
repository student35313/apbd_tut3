namespace apbd_hw1;

public abstract class Transport
    {
        public double MaxSpeed { get; }
        public int MaxContainerCount { get; }
        public double MaxWeightTons { get; }
        public double CurrWeightTons { get; set; }
        
        protected List<Container> _containers = new List<Container>();

        protected Transport(double maxSpeed, int maxContainerCount, double maxWeightTons, double currWeightTons)
        {
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxWeightTons = maxWeightTons;
            CurrWeightTons = currWeightTons;
        }
        
        public virtual void AddContainer(Container container)
        {
            if (_containers.Count >= MaxContainerCount)
            {
                throw new OverloadException("Transport overloaded: maximum container count reached.");
            }
            
            double newWeight = CurrWeightTons + (container.TareWeight + container.CargoMass) / 1000.0;
            if (newWeight > MaxWeightTons)
            {
                throw new OverloadException($"Transport overloaded: total weight {newWeight} tons exceeds the limit of {MaxWeightTons} tons.");
            }
            
            _containers.Add(container);
            CurrWeightTons = newWeight;
        }
        
        public virtual void AddContainers(IEnumerable<Container> containersToLoad)
        {
            foreach (var container in containersToLoad)
            {
                AddContainer(container);
            }
        }
        
        public virtual void RemoveContainer(string serialNumber)
        {
            var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container == null)
                throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
            
            _containers.Remove(container);
            CurrWeightTons = _containers.Sum(c => (c.TareWeight + c.CargoMass)) / 1000.0;
        }
        
        public virtual void ReplaceContainer(string serialNumber, Container newContainer)
        {
            RemoveContainer(serialNumber);
            AddContainer(newContainer);
        }
        
        public virtual void TransferContainer(string serialNumber, Transport destination)
        {
            Container container = null;

            foreach (var c in _containers)
            {
                if (c.SerialNumber == serialNumber) container = c;
            }
            
            if (container == null)
                throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
            
            _containers.Remove(container);
            CurrWeightTons = _containers.Sum(c => (c.TareWeight + c.CargoMass)) / 1000.0;
            destination.AddContainer(container);
        }

        
    }