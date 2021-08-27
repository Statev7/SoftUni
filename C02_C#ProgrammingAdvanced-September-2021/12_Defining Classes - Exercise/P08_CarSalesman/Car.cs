namespace P08_CarSalesman
{
    using System.Text;

    public class Car
    {
        public Car()
        {
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine)
            :this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public int Weight  { get; private set; }

        public string Color { get; private set; }

        public override string ToString()
        {
            string displacement = this.Engine.Displacement > 0 ? this.Engine.Displacement.ToString() : "n/a";
            string weight = this.Weight > 0 ? this.Weight.ToString() : "n/a";

            StringBuilder str = new StringBuilder();
            str.AppendLine($"{this.Model}:");
            str.AppendLine($"  {this.Engine.Model}:");
            str.AppendLine($"    Power: {this.Engine.Power}");
            str.AppendLine($"    Displacement: {displacement}");
            str.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            str.AppendLine($"  Weight: {weight}");
            str.Append($"  Color: {this.Color}");

            return str.ToString(); 
        }
    }
}
