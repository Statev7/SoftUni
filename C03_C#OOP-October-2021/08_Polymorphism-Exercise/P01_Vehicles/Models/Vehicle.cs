namespace Vehicles.Models
{
    using Vehicles.Common;
    using Vehicles.Contracts;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double fuel = distance * this.FuelConsumption;
            bool canContinue = this.FuelQuantity >= fuel;
            if (canContinue)
            {
                this.FuelQuantity -= fuel;

                return string.Format(GlobalMessages.TRAVELLED_MESSAGE, this.GetType().Name, distance);
            }

            return string.Format(GlobalMessages.NEED_REFUEL_MESSAGE, this.GetType().Name);
        }

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
