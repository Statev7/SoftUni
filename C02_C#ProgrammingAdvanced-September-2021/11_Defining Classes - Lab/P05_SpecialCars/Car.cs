namespace P05_SpecialCars
{
    using System.Text;

    public class Car
    {
        private const double DESTINATION_VALUE = 20;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tyres)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tyres;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive()
        {
            double fuel = (this.FuelConsumption * DESTINATION_VALUE) / 100;
            this.FuelQuantity -= fuel;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Make: {this.Make}");
            str.AppendLine($"Model: {this.Model}");
            str.AppendLine($"Year: {this.Year}");
            str.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            str.Append($"FuelQuantity: {this.FuelQuantity}");

            return str.ToString(); 
        }
    }
}
