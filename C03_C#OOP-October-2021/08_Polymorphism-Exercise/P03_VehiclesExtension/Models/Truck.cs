namespace VehiclesExtension.Models
{
    using VehiclesExtension.Common;

    public class Truck : Vehicle
    {
        private const double AIR_CONSUMPTION = 1.6;
        private const double QTY_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONSUMPTION, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            VenhicleValidator.CanFitFuel(liters, this.TankCapacity);

            double litersToRefuel = liters * QTY_MODIFIER;

            this.FuelQuantity += litersToRefuel;
        }
    }
}
