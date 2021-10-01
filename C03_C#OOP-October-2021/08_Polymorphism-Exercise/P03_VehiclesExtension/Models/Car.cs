namespace VehiclesExtension.Models
{
    using VehiclesExtension.Common;

    public class Car : Vehicle
    {
        private const double AIR_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONSUMPTION, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            VenhicleValidator.CanFitFuel(liters, this.TankCapacity);

            this.FuelQuantity += liters;
        }
    }
}
