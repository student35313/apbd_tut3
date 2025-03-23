namespace apbd_hw1;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; } //percents
    
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
        CargoMass *= 0.05;
        Pressure *= 0.05;
    }
    
    public new void LoadCargo(double mass)
    {
        try
        {
            base.LoadCargo(mass);
            Pressure += Pressure * (1 / MaximumPayload * mass);
        }
        catch (OverfillException)
        {
            NotifyHazard(SerialNumber, $"Attempt to load {mass} kg exceeds maximum payload {MaximumPayload} kg.");
            throw;
        }
        
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Pressure={Pressure} atm";
    }

}