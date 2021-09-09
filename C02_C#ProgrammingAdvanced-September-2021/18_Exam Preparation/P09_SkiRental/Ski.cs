namespace SkiRental
{
    using System.Text;

    public class Ski
    {
        public Ski(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Manufacturer} - {this.Model} - {this.Year}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
