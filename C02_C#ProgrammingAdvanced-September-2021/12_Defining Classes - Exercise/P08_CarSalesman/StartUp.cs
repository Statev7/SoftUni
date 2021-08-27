namespace P08_CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();

            ReadEngines(allEngines);
            ReadCars(allEngines, allCars);

            foreach (var car in allCars)
            {
                Console.WriteLine(car);
            }
        }

        private static void ReadEngines(List<Engine> allEngines)
        {
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                var engineArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineArg[0];
                int power = int.Parse(engineArg[1]);
                Engine engine = new Engine();

                if (engineArg.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (engineArg.Length == 3)
                {
                    int displacement;
                    bool isNumber = int.TryParse(engineArg[2], out displacement);
                    if (isNumber)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineArg[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineArg.Length == 4)
                {
                    int displacement = int.Parse(engineArg[2]);
                    string efficiency = engineArg[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                allEngines.Add(engine);
            }
        }

        private static void ReadCars(List<Engine> allEngines, List<Car> allCars)
        {
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                var carArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArg[0];
                string engineModel = carArg[1];
                Engine engine = allEngines.
                    Where(x => x.Model == engineModel)
                    .SingleOrDefault();

                Car car = new Car();

                if (carArg.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArg.Length == 3)
                {
                    int weight;
                    bool isNumber = int.TryParse(carArg[2], out weight);
                    if (isNumber)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = carArg[2];
                        car = new Car(model, engine, color);
                    }
                }
                else if (carArg.Length == 4)
                {
                    int weight = int.Parse(carArg[2]);
                    string color = carArg[3];

                    car = new Car(model, engine, weight, color);
                }

                allCars.Add(car);
            }
        }
    }
}
