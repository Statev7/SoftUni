namespace VehiclesExtension.Models
{
    using VehiclesExtension.Common;

    public class Bus : Vehicle
    {
        private const double QTR_VALUE = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + QTR_VALUE, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            double fuel = distance * (this.FuelConsumption - QTR_VALUE);
            bool canContinue = this.FuelQuantity >= fuel;
            if (canContinue)
            {
                this.FuelQuantity -= fuel;

                return string.Format(GlobalMessages.TRAVELLED_MESSAGE, this.GetType().Name, distance);
            }

            return string.Format(GlobalMessages.NEED_REFUEL_MESSAGE, this.GetType().Name);
        }

        public override void Refuel(double liters)
        {
            VenhicleValidator.CanFitFuel(liters, this.TankCapacity);

            var litersToRefuel = QTR_VALUE == 0 ? liters : liters * QTR_VALUE;

            this.FuelQuantity += litersToRefuel;
        }
    }
}
