namespace NeedForSpeed.Vehicles.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_FUEL_CONSUMPTION_VALUE = 8;

        public RaceMotorcycle(int horsepower, double fuel)
            :base(horsepower, fuel)
        {
            this.DefaultFuelConsumption = DEFAULT_FUEL_CONSUMPTION_VALUE;
        }
    }
}
