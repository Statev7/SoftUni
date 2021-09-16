namespace NeedForSpeed.Vehicles.Cars
{
    public class Car : Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION_VALUE = 3;

        public Car(int horsepower, double fuel)
            :base(horsepower, fuel)
        {
            this.DefaultFuelConsumption = DEFAULT_FUEL_CONSUMPTION_VALUE;
        }
    }
}
