namespace apbd_hw1;

public abstract class Container
{
    public double CargoMass { get; protected set; }
    
    public double Height { get;  }
    public double Depth { get; }
    
    public double TareWeight { get; }
    
    public double MaximumPayload { get; }
    
    public string SerialNumber { get; }
    
    public string ContainerTypeCode { get; }
    
    private static Dictionary<string, int> Counters = new Dictionary<string, int>();
    
    protected Container(double height, double tareWeight, double depth, double maximumPayload, string containerTypeCode)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaximumPayload = maximumPayload;
        CargoMass = 0;
        ContainerTypeCode = containerTypeCode;
        SerialNumber = GenerateSerialNumber();
    }

    public static int GetNextNumber(string containerType)
    {
        if (Counters.ContainsKey(containerType))
            Counters[containerType]++;
        else
            Counters[containerType] = 1;

        return Counters[containerType];
    }
    private string GenerateSerialNumber()
    {
        int uniqueNumber = GetNextNumber(ContainerTypeCode);
        return $"KON-{ContainerTypeCode}-{uniqueNumber}";
    }
    
    public void EmptyCargo()
    {
        CargoMass = 0;
    }
    public void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaximumPayload)
            throw new OverfillException($"Cargo mass {mass} exceeds maximum payload of {MaximumPayload}.");
            
        CargoMass += mass;
    }
    
    public override string ToString()
    {
        return $"Container {SerialNumber}: Type={ContainerTypeCode}, CargoMass={CargoMass} kg, TareWeight={TareWeight} kg, MaximumPayload={MaximumPayload} kg";
    }
}