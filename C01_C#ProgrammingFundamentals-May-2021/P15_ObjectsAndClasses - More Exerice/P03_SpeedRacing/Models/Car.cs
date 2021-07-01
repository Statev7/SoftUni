namespace P03_SpeedRacing.Models
{
    using System;

    public class Car
    {
        const string CAR_CANNOT_MOVE_ERROR_MESSAGE = "Insufficient fuel for the drive";

        public Car(string model, double fuelAmount, double fuelConsumptionForOneKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionForOneKm = fuelConsumptionForOneKm;
            this.TraveledDistance = 0;
        }

        public string Model { get; private set; }

        public double FuelAmount { get; private set; }

        public double FuelConsumptionForOneKm { get; private set; }

        public double TraveledDistance { get; private set; }

        public void Drive(double distance)
        {
            double sum = this.FuelConsumptionForOneKm * distance;

            if (sum > this.FuelAmount)
            {
                Console.WriteLine(CAR_CANNOT_MOVE_ERROR_MESSAGE);
            }
            else
            {
                this.FuelAmount -= sum;
                this.TraveledDistance += distance;
            }
        }

        public override string ToString()
        {
            string result = $"{this.Model} {this.FuelAmount:F2} {this.TraveledDistance}";
            return result.ToString();
        }

    }
}
