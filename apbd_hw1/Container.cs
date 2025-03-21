namespace apbd_hw1;

public abstract class Container
{
    public double CargoMass { get; set; }
    
    public double Height { get; set; }
    public double Depth { get; set; }
    
    public double TareWeight { get; set; }
    
    public double MaximumPayload { get; set; }
    
    public string SerialNumber { get; set; }
    
    public string ContainerTypeCode { get; set;}
    
    private static Dictionary<string, int> Counters = new Dictionary<string, int>();
    
    protected Container(double height, double tareWeight, double depth, double maximumPayload, string containerTypeCode)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaximumPayload = maximumPayload;
        CargoMass = 0;
        SerialNumber = GenerateSerialNumber();
        ContainerTypeCode = containerTypeCode;
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
        if (mass > MaximumPayload)
            throw new OverfillException($"Cargo mass {mass} exceeds maximum payload of {MaximumPayload}.");
            
        CargoMass = mass;
    }
}