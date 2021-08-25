namespace P05_SpecialCars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_TIRES = "No more tires";
        private const string COMMAND_TO_STOP_READ_ENGINES = "Engines done";
        private const string COMMAND_TO_STOP_READ_CARS = "Show special";

        public static void Main()
        {
            List<Tire[]> allTires = new List<Tire[]>();
            List<Engine> allEngines = new List<Engine>();
            List<Car> cars = new List<Car>();
            ReadTires(allTires);
            ReadEngine(allEngines);
            ReadCars(allTires, allEngines, cars);
            PrintSpecialCars(cars);

        }

        private static void ReadTires(List<Tire[]> allTires)
        {
            string tiresArguments = Console.ReadLine();
            while (tiresArguments != COMMAND_TO_STOP_READ_TIRES)
            {
                Tire[] tires = new Tire[4];
                int tireIndex = 0;

                var splitedTiresArg = tiresArguments.Split(" ");
                for (int index = 0; index < splitedTiresArg.Length; index += 2)
                {
                    int year = int.Parse(splitedTiresArg[index]);
                    double pressure = double.Parse(splitedTiresArg[index + 1]);

                    Tire tire = new Tire(year, pressure);
                    tires[tireIndex++] = tire;
                }

                allTires.Add(tires);

                tiresArguments = Console.ReadLine();
            }
        }

        private static void ReadEngine(List<Engine> allEngines)
        {
            string engineArguments = Console.ReadLine();
            while (engineArguments != COMMAND_TO_STOP_READ_ENGINES)
            {
                var spliedEngineArg = engineArguments.Split(" ");
                int horsePower = int.Parse(spliedEngineArg[0]);
                double cubicCapacity = double.Parse(spliedEngineArg[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                allEngines.Add(engine);

                engineArguments = Console.ReadLine();
            }
        }

        private static void ReadCars(List<Tire[]> allTires, List<Engine> allEngines, List<Car> cars)
        {
            string carsArguments = Console.ReadLine();
            while (carsArguments != COMMAND_TO_STOP_READ_CARS)
            {
                var splitedCarsArg = carsArguments.Split(" ");

                string make = splitedCarsArg[0];
                string model = splitedCarsArg[1];
                int year = int.Parse(splitedCarsArg[2]);
                double fuelQuantity = double.Parse(splitedCarsArg[3]);
                double fuelConsumption = double.Parse(splitedCarsArg[4]);
                int engineIndex = int.Parse(splitedCarsArg[5]);
                int tiresIndex = int.Parse(splitedCarsArg[6]);

                Engine engine = allEngines[engineIndex];
                Tire[] tires = allTires[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);

                carsArguments = Console.ReadLine();
            }
        }

        private static void PrintSpecialCars(List<Car> cars)
        {
            foreach (var car in cars
                            .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330))
            {
                double tireSum = 0;

                foreach (var tire in car.Tires)
                {
                    tireSum += tire.Pressure;
                }

                if (tireSum >= 9 && tireSum <= 10)
                {
                    car.Drive();
                    Console.WriteLine(car);
                }
            }
        }
    }
}
