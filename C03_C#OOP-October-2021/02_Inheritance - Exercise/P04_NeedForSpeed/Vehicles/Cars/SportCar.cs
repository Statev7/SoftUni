namespace NeedForSpeed.Vehicles.Cars
{
    public class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION_VALUE = 10;

        public SportCar(int horsepower, double fuel)
            :base(horsepower, fuel)
        {
            this.DefaultFuelConsumption = DEFAULT_FUEL_CONSUMPTION_VALUE;
        }

    }
}
