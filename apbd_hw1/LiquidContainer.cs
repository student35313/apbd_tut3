namespace apbd_hw1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }
    
    public LiquidContainer(double height, double tareWeight, double depth, double maximumPayload, bool isHazardous)
        : base(height, tareWeight, depth, maximumPayload, "L")
    {
        IsHazardous = isHazardous;
    }
    
    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"Hazard notification for container {containerNumber}: {message}");
    }
    
    public new void LoadCargo(double mass)
    {
        double allowedLimit = IsHazardous ? MaximumPayload * 0.5 : MaximumPayload * 0.9;
        if (mass > allowedLimit)
        {
            NotifyHazard(SerialNumber, $"Attempt to load {mass}kg exceeds allowed limit of {allowedLimit}kg.");
            throw new OverfillException($"Cargo mass {mass} exceeds allowed limit of {allowedLimit}.");
        }
        base.LoadCargo(mass);
    }
}