namespace P06_VehicleCatalogue.Models
{
    using System.Collections.Generic;

    using P06_VehicleCatalogue.Models.Vehicle;

    public class Catalogue
    {
        public Catalogue()
        {
            Car = new List<Car>();
            Truck = new List<Truck>();
        }

        public List<Car> Car { get; private set; }

        public List<Truck> Truck { get; private set; }
    }
}
