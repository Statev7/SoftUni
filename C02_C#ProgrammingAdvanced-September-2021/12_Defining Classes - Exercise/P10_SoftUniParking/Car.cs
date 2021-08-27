namespace SoftUniParking
{
    using System.Text;

    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Make: {this.Make}");
            str.AppendLine($"Model: {this.Model}");
            str.AppendLine($"HorsePower: {this.HorsePower}");
            str.Append($"HorsePower: {this.RegistrationNumber}");

            return str.ToString(); 
        }
    }
}
