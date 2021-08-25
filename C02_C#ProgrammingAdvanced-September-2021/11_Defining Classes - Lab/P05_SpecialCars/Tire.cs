namespace P05_SpecialCars
{
    using System;

    public class Tire
    {
        private const string YEAR_AND_PRESSURE_ERROR_MESSAGE = "The year and a pressure cannot be negative numbers.";

        public Tire(int year, double pressure)
        {
            if (year < 0 || pressure < 0)
            {
                throw new ArgumentException(YEAR_AND_PRESSURE_ERROR_MESSAGE);
            }

            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; set; }

        public double Pressure { get; set; }
    }
}
