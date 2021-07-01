namespace P04_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int carCount = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < carCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = arguments[0];
                int engineSpeed = int.Parse(arguments[1]);
                int enginePower = int.Parse(arguments[2]);
                int cargoWeight = int.Parse(arguments[3]);
                string cargoType = arguments[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo);

                allCars.Add(car);
            }

            string filter = Console.ReadLine();
            PrintResult(allCars, filter);
        }

        private static void PrintResult(List<Car> allCars, string filter)
        {
            var filtered = allCars
                .Where(x => x.Cargo.CargoType == filter)
                .ToList();

            if (filter == "fragile")
            {
                filtered
                    .Where(x => x.Cargo.CargoWeight < 1000)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else
            {
                filtered
                    .Where(x => x.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public override string ToString()
        {
            string result = $"{this.Model}";

            return result.ToString();
        }
    }

    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; private set; }

        public int EnginePower { get; private set; }

    }

    public class Cargo
    {
        public Cargo(int carrgoWeight, string cargoType)
        {
            this.CargoWeight = carrgoWeight;
            this.CargoType = cargoType;
        }

        public int CargoWeight { get; private set; }

        public string CargoType { get; private set; }
    }
}
