namespace P06_VehicleCatalogue.Models.Vehicle
{
    using System.Text;

    public class Car : VehicleBaseModel
    {
        public Car(string model, string color, int horsepower)
            : base(model, color, horsepower)
        {

        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Type: Car");
            str.AppendLine($"Model: {this.Model}");
            str.AppendLine($"Color: {this.Color}");
            str.AppendLine($"Horsepower: {this.Hoursepower}");

            return str.ToString();
        }
    }
}
