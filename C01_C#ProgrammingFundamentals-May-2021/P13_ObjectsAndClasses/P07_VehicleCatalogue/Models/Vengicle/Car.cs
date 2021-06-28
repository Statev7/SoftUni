namespace P07_VehicleCatalogue.Models.Vengicle
{
    using System.Text;

    public class Car : VehicleBaseModel
    {
        public Car(string brand, string model, int horsePower)
            : base(brand, model)
        {
            this.HoursePower = horsePower;
        }

        public int HoursePower { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{this.Brand}: {this.Model} - {this.HoursePower}hp");

            return stringBuilder.ToString();
        }
    }
}
