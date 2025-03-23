namespace apbd_hw1;



public class Ship : Transport
{
    public Ship(double maxSpeed, int maxContainerCount, double maxWeightTons)
        : base(maxSpeed, maxContainerCount, maxWeightTons, 0)
    {
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