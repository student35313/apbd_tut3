namespace apbd_hw1;

public static class TemperatureRequirements
{
    public static double GetRequiredTemperature(RefrigeratedProduct product)
    {
        return product switch
        {
            RefrigeratedProduct.Bananas       => 13.3,
            RefrigeratedProduct.Chocolate     => 18,
            RefrigeratedProduct.Fish          => 2,
            RefrigeratedProduct.Meat          => -15,
            RefrigeratedProduct.IceCream      => -18,
            RefrigeratedProduct.FrozenPizza   => -30,
            RefrigeratedProduct.Cheese        => 7.2,
            RefrigeratedProduct.Sausages      => 5,
            RefrigeratedProduct.Butter        => 20.5,
            RefrigeratedProduct.Eggs          => 9,
            _ => 0
        };
    }
}