namespace VehiclesExtension.Models
{
    using VehiclesExtension.Common;
    using VehiclesExtension.Contracts;

    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }


        public double FuelConsumption { get; protected set; }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                if (this.FuelQuantity > value)
                {
                    this.FuelQuantity = 0;
                }

                this.tankCapacity = value;
            }
        }

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
            return $"{this.GetType().Name}: {this.FuelConsumption:F2}";
        }
    }
}
