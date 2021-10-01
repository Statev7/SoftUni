namespace Vehicles.Models
{
    using Vehicles.Common;

    public class Truck : Vehicle
    {
        private const double AIR_CONSUMPTION = 1.6;
        private const double QTY_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + AIR_CONSUMPTION)
        {
        }

        public override void Refuel(double liters)
        {
            double litersToRefuel = liters * QTY_MODIFIER;

            this.FuelQuantity += litersToRefuel;
        }
    }
}
