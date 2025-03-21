namespace apbd_hw1;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    
    public GasContainer(double height, double tareWeight, double depth, double maximumPayload, double pressure)
        : base(height, tareWeight, depth, maximumPayload, "G")
    {
        Pressure = pressure;
    }
    
    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"[HAZARD] Container {containerNumber}: {message}");
    }

    
    public new void EmptyCargo()
    {
        CargoMass *= 0.05; // оставляем 5%
    }
    
    public new void LoadCargo(double mass)
    {
        if (mass > MaximumPayload)
        {
            NotifyHazard(SerialNumber, $"Attempt to load {mass} kg exceeds maximum payload {MaximumPayload} kg.");
            throw new OverfillException($"Cargo mass {mass} exceeds maximum payload of {MaximumPayload}.");
        }
        
        base.LoadCargo(mass);
    }
}