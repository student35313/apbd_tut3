namespace apbd_hw1;

public class RefrigeratedContainer : Container
    {
        public RefrigeratedProduct ProductType { get; set; }
        
        public double CurrentTemperature { get; private set; }
        
        public RefrigeratedContainer(
            RefrigeratedProduct product,
            double height,
            double tareWeight,
            double depth,
            double maximumPayload,
            double initialTemperature)
            : base(height, tareWeight, depth, maximumPayload, "C") 
        {
            ProductType = product;
            SetTemperature(initialTemperature);
        }
        
        public void SetTemperature(double newTemperature)
        {
            double requiredTemp = TemperatureRequirements.GetRequiredTemperature(ProductType);
            if (newTemperature < requiredTemp)
            {
                throw new ArgumentException(
                    $"New temperature ({newTemperature}°C) cannot be lower " +
                    $"than required temperature ({requiredTemp}°C) for {ProductType}.");
            }

            CurrentTemperature = newTemperature;
        }
        
    }