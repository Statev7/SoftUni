namespace P07_VehicleCatalogue.Models.Vengicle
{
    public abstract class VehicleBaseModel
    {
        protected VehicleBaseModel(string brand, string model)
        {
            this.Brand = brand;
            this.Model = model;
        }

        public string Brand { get; private set; }

        public string Model { get; private set; }
    }
}
