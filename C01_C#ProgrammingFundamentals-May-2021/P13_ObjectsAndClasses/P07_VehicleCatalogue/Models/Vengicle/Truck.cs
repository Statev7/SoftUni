namespace P07_VehicleCatalogue.Models.Vengicle
{
    using System.Text;

    public class Truck : VehicleBaseModel
    {
        public Truck(string brand, string model, int weight)
            : base(brand, model)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{this.Brand}: {this.Model} - {this.Weight}kg");

            return stringBuilder.ToString();
        }
    }
}
