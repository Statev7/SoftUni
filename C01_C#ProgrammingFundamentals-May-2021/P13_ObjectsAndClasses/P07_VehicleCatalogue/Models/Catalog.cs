namespace P07_VehicleCatalogue.Models
{
    using System.Collections.Generic;

    using P07_VehicleCatalogue.Models.Vengicle;

    public class Catalog
    {
        public Catalog()
        {
            Car = new List<Car>();
            Truck = new List<Truck>();
        }

        public List<Car> Car { get; private set; }

        public List<Truck> Truck { get; private set; }

    }
}
