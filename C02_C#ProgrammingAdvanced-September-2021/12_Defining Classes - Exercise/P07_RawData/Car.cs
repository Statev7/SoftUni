using System.Text;

namespace P07_RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }

        public string Model { get;}

        public Engine Engine { get;}

        public Cargo Cargo { get; }

        public Tire[] Tire { get;  }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"{this.Model}");

            return str.ToString(); 
        }
    }
}
