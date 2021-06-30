namespace P06_VehicleCatalogue.Models.Vehicle
{
    public abstract class VehicleBaseModel
    {
        protected VehicleBaseModel(string model, string color, int hoursepower)
        {
            this.Model = model;
            this.Color = color;
            this.Hoursepower = hoursepower;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Hoursepower { get; private set; }
    }
}
