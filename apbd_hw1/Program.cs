// See https://aka.ms/new-console-template for more information

using apbd_hw1;

class Program
{

    static void Main(string[] args)
    {
        LiquidContainer liquidContainer = new LiquidContainer(height: 200, tareWeight: 500, depth: 300,
            maximumPayload: 1000, isHazardous: false);
        GasContainer gasContainer =
            new GasContainer(height: 250, tareWeight: 600, depth: 350, maximumPayload: 1200, pressure: 5);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(
            product: RefrigeratedProduct.Meat,
            height: 220, tareWeight: 550, depth: 320, maximumPayload: 800, initialTemperature: 5);

        try
        {
            liquidContainer.LoadCargo(800);
            Console.WriteLine("Liquid container loaded with 800 kg of cargo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading liquid container: " + ex.Message);
        }

        try
        {
            gasContainer.LoadCargo(1100);
            Console.WriteLine("Gas container loaded with 1100 kg of cargo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading gas container: " + ex.Message);
        }

        try
        {
            refrigeratedContainer.LoadCargo(600);
            Console.WriteLine("Refrigerated container loaded with 600 kg of cargo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading refrigerated container: " + ex.Message);
        }

        Ship ship1 = new Ship(maxSpeed: 20, maxContainerCount: 5, maxWeightTons: 10);

        try
        {
            ship1.AddContainer(liquidContainer);
            Console.WriteLine("Liquid container added to ship1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding container to ship1: " + ex.Message);
        }

        List<Container> containerList = new List<Container> { gasContainer, refrigeratedContainer };
        try
        {
            ship1.AddContainers(containerList);
            Console.WriteLine("Gas and refrigerated containers added to ship1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding containers to ship1: " + ex.Message);
        }

        try
        {
            ship1.RemoveContainer(gasContainer.SerialNumber);
            Console.WriteLine($"Gas container {gasContainer.SerialNumber} removed from ship1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error removing container: " + ex.Message);
        }

        refrigeratedContainer.EmptyCargo();
        Console.WriteLine("Refrigerated container cargo unloaded.");

        LiquidContainer newLiquidContainer = new LiquidContainer(height: 200, tareWeight: 500, depth: 300,
            maximumPayload: 1000, isHazardous: false);
        try
        {
            ship1.ReplaceContainer(liquidContainer.SerialNumber, newLiquidContainer);
            Console.WriteLine(
                $"Liquid container {liquidContainer.SerialNumber} replaced with new container {newLiquidContainer.SerialNumber} on ship1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error replacing container: " + ex.Message);
        }

        Ship ship2 = new Ship(maxSpeed: 25, maxContainerCount: 3, maxWeightTons: 8);
        try
        {
            ship1.TransferContainer(refrigeratedContainer.SerialNumber, ship2);
            Console.WriteLine(
                $"Refrigerated container {refrigeratedContainer.SerialNumber} transferred from ship1 to ship2.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error transferring container: " + ex.Message);
        }

        Console.WriteLine("New Liquid Container Info:");
        Console.WriteLine(newLiquidContainer.ToString());
        Console.WriteLine("Refrigerated Container Info:");
        Console.WriteLine(refrigeratedContainer.ToString());

        Console.WriteLine("Ship1 Info:");
        Console.WriteLine(ship1.ToString());
        Console.WriteLine("Ship2 Info:");
        Console.WriteLine(ship2.ToString());
        
    }
}      