namespace Vehicles.Models
{
    using Vehicles.Common;

    public class Car : Vehicle
    {
        private const double AIR_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + AIR_CONSUMPTION)
        {
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
