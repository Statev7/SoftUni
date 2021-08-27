namespace P08_CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power)
            :this()
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            :this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            :this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displacement { get; private set; }

        public string Efficiency { get; private set; }
    }
}
