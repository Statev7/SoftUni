namespace P07_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Car> allCars = new List<Car>(); 

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                int tireIndex = 0;
                var carArgmunts = Console.ReadLine()
                    .Split(" ");

                string model = carArgmunts[0];
                int engineSpeed = int.Parse(carArgmunts[1]);
                int enginePower = int.Parse(carArgmunts[2]);
                int cargoWeight = int.Parse(carArgmunts[3]);
                string cargoType = carArgmunts[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                for (int index = 5; index < carArgmunts.Length; index+=2)
                {
                    double tirePressure = double.Parse(carArgmunts[index]);
                    int tireAge = int.Parse(carArgmunts[index + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);

                    tires[tireIndex++] = tire;
                }

                Car car = new Car(model, engine, cargo, tires);

                allCars.Add(car);
            }

            string filter = Console.ReadLine();

            if (filter == "fragile")
            {
                foreach (var car in allCars
                    .Where(x => x.Cargo.Type == filter && x.Tire.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car);
                }
            }
            else if(filter == "flamable")
            {
                foreach (var car in allCars
                    .Where(x => x.Cargo.Type == filter && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
