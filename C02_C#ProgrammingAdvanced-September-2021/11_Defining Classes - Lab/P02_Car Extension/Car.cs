namespace CarManufacturer
{
    using System;
    using System.Text;

    public class Car
    {
        private const string NOT_ENOUGH_FUEL_ERROR_MESSAGE = "Not enough fuel to perform this trip!";

        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;
            bool canContinue = this.FuelQuantity - neededFuel >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine(NOT_ENOUGH_FUEL_ERROR_MESSAGE);
            }
        }

        public string WhoAmI()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Make {this.Make}");
            str.AppendLine($"Model {this.Model}");
            str.AppendLine($"Year {this.Year}");
            str.AppendLine($"Fuel {this.FuelQuantity:F2}L");

            return str.ToString();
        }
    }
}
