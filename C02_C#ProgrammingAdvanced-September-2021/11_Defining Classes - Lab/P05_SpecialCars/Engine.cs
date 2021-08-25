namespace P05_SpecialCars
{
    using System;

    public class Engine
    {
        private const string HORSEPOWER_AND_CUBIC_CAPACITY_ERROR_MESSAGE = "Horsepower and cubic capacity cannot be negative numbers.";
        public Engine(int horsePower, double cubicCapacity)
        {
            if (horsePower <= 0 || cubicCapacity <= 0)
            {
                throw new ArgumentException(HORSEPOWER_AND_CUBIC_CAPACITY_ERROR_MESSAGE);
            }

            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; }

        public double CubicCapacity { get; }
    }
}
