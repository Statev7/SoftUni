namespace P06_VehicleCatalogue.Models.Vehicle
{
    using System.Text;

    public class Truck : VehicleBaseModel
    {
        public Truck(string model, string color, int horsepower)
            : base(model, color, horsepower)
        {

        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Type: Truck");
            str.AppendLine($"Model: {this.Model}");
            str.AppendLine($"Color: {this.Color}");
            str.AppendLine($"Horsepower: {this.Hoursepower}");

            return str.ToString();
        }
    }
}
