namespace SkiRental
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SkiRental
    {
        private readonly HashSet<Ski> date;

        public SkiRental(string name, int capacity)
        {
            this.date = new HashSet<Ski>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => this.date.Count;}

        public void Add(Ski ski)
        {
            bool canAddSki = this.Capacity > this.date.Count;
            if (canAddSki)
            {
                this.date.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var skiToRemove = this.IsSkiExist(manufacturer, model);
            if (skiToRemove != null)
            {
                this.date.Remove(skiToRemove);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            var newestSki = this.date
                .OrderByDescending(x => x.Year)
                .FirstOrDefault();

            if (newestSki != null)
            {
                return newestSki;
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var ski = this.IsSkiExist(manufacturer, model);
            if (ski != null)
            {
                return ski;
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.date)
            {
                sb.AppendLine($"{ski}");
            }

            return sb.ToString().TrimEnd();
        }

        private Ski IsSkiExist(string manufacturer, string model)
        {
            return this.date
                            .Where(x => x.Manufacturer == manufacturer && x.Model == model)
                            .SingleOrDefault();
        }
    }
}
