namespace StreetRacing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Race
    {
        private readonly HashSet<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.participants = new HashSet<Car>();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count { get => this.participants.Count;}

        public void Add(Car car)
        {
            var searchCar = this.participants
                .Where(x => x.LicensePlate == car.LicensePlate)
                .SingleOrDefault();

            bool canAddCar = this.Capacity > this.participants.Count && 
                             searchCar == null && 
                             car.HorsePower <= this.MaxHorsePower;
            if (canAddCar)
            {
                this.participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var car = IsCarExist(licensePlate);
            if (car != null)
            {
                this.participants.Remove(car);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            var car = IsCarExist(licensePlate);
            if (car != null)
            {
                return car;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            var car = this.participants
                .OrderByDescending(x => x.HorsePower)
                .FirstOrDefault();

            if (car != null)
            {
                return car;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in this.participants)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }

        private Car IsCarExist(string licensePlate)
        {
            return this.participants
                            .Where(x => x.LicensePlate == licensePlate)
                            .SingleOrDefault();
        }
    }
}
