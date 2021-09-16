namespace NeedForSpeed.Vehicles
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION_VALUE = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = DEFAULT_FUEL_CONSUMPTION_VALUE;
        }

        public double DefaultFuelConsumption  { get; protected set; }

        public virtual double FuelConsumption  { get; set; }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelNeeded = this.DefaultFuelConsumption * kilometers;
            if (fuelNeeded <= this.Fuel)
            {
                this.Fuel -= fuelNeeded;
            }
        }
    }
}
