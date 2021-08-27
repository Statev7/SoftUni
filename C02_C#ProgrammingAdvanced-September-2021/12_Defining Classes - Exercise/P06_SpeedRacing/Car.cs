namespace P06_SpeedRacing
{
    using System;
    using System.Text;

    public class Car
    {
        private const string INSUFFICIENT_FUEL_ERROR_MESSAGE = "Insufficient fuel for the drive";

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(double amountOfKm)
        {
            double needFuel = this.FuelConsumptionPerKilometer * amountOfKm;
            bool canContinue = this.FuelAmount - needFuel >= 0;

            if (canContinue)
            {
                this.FuelAmount -= needFuel;
                this.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine(INSUFFICIENT_FUEL_ERROR_MESSAGE);
            } 
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}");

            return str.ToString(); 
        }
    }
}
