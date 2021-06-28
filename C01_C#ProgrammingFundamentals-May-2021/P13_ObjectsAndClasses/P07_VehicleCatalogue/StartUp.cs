namespace P07_VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using P07_VehicleCatalogue.Models;
    using P07_VehicleCatalogue.Models.Vengicle;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                string command = arguments[0];

                bool isStopCommand = command == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string brand = arguments[1];
                string model = arguments[2];

                switch (command)
                {
                    case "Car":
                        int horsePower = int.Parse(arguments[3]);
                        Car car = new Car(brand, model, horsePower);
                        catalog.Car.Add(car);
                        break;
                    case "Truck":
                        int weight = int.Parse(arguments[3]);
                        Truck truck = new Truck(brand, model, weight);
                        catalog.Truck.Add(truck);
                        break;
                }
            }

            PrintResult(catalog);
        }

        private static void PrintResult(Catalog catalog)
        {
            var finalCarList = catalog.Car
                .OrderBy(x => x.Brand)
                .ToList();

            var finalTruckList = catalog.Truck
                .OrderBy(x => x.Brand)
                .ToList();

            if (catalog.Car.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in finalCarList)
                {
                    Console.WriteLine(car);
                }

                if (catalog.Truck.Count != 0)
                {
                    Console.WriteLine("Trucks:");
                    foreach (Truck truck in finalTruckList)
                    {
                        Console.WriteLine(truck);
                    }
                }
            }
            else if (catalog.Truck.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in finalTruckList)
                {
                    Console.WriteLine(truck);
                }

                if (catalog.Car.Count != 0)
                {
                    Console.WriteLine("Cars:");
                    foreach (Car car in finalCarList)
                    {
                        Console.WriteLine(car);
                    }
                }
            }
        }
    }
}
