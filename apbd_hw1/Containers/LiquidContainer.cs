namespace apbd_hw1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(double height, double tareWeight, double depth, double maximumPayload, bool isHazardous)
        : base(height, tareWeight, depth, maximumPayload, "L")
    {
        IsHazardous = isHazardous;
    }
    
    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"Hazard notification for container {containerNumber}: {message}");
    }
    
    public override void LoadCargo(double mass)
    {
        double allowedLimit = IsHazardous ? MaximumPayload * 0.5 : MaximumPayload * 0.9;
        if (CargoMass + mass > allowedLimit)
        {
            NotifyHazard(SerialNumber, $"Attempt to load {mass}kg exceeds allowed limit of {allowedLimit}kg.");
            throw new OverfillException($"Cargo mass {mass} exceeds allowed limit of {allowedLimit}.");
        }
        CargoMass += mass;
    }
    public override string ToString()
    {
        return base.ToString() + $", Hazardous={IsHazardous}";
    }
}