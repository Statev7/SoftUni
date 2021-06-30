namespace P06_VehicleCatalogue
{
    using System;
    using System.Linq;

    using P06_VehicleCatalogue.Models;
    using P06_VehicleCatalogue.Models.Vehicle;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";
        const string COMMAND_TO_CLOSE_CATALOGUE = "Close the Catalogue";

        public static void Main()
        {
            Catalogue catalogue = new Catalogue();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = arguments[0];
                bool isStopCommand = type == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string model = arguments[1];
                string color = arguments[2];
                int horsepower = int.Parse(arguments[3]);

                switch (type)
                {
                    case "car":
                        Car car = new Car(model, color, horsepower);
                        catalogue.Car.Add(car);
                        break;
                    case "truck":
                        Truck truck = new Truck(model, color, horsepower);
                        catalogue.Truck.Add(truck);
                        break;
                }
            }

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_CLOSE_CATALOGUE;
                if (isStopCommand)
                {
                    break;
                }

                bool isCar = CheckIfTheModelIsACar(catalogue, arguments);
                PrintCarArguments(catalogue, arguments, isCar);
            }

            HoursepowerSum(catalogue);
        }

        private static bool CheckIfTheModelIsACar(Catalogue catalogue, string model)
        {
            bool isValid = catalogue.Car
                .Select(x => x.Model)
                .Contains(model);

            return isValid;
        }

        private static void PrintCarArguments(Catalogue catalogue, string arguments, bool isCar)
        {
            if (isCar)
            {
                var car = catalogue.Car
                    .Where(x => x.Model == arguments)
                    .SingleOrDefault();

                Console.Write(car);
            }
            else
            {
                var truck = catalogue.Truck
                    .Where(x => x.Model == arguments)
                    .SingleOrDefault();

                Console.Write(truck);
            }
        }

        private static void HoursepowerSum(Catalogue catalogue)
        {
            double carHorsepowerSum = 0;
            double truckHorsePowerSum = 0;
            foreach (var car in catalogue.Car)
            {
                carHorsepowerSum += car.Hoursepower;
            }

            foreach (var truck in catalogue.Truck)
            {
                truckHorsePowerSum += truck.Hoursepower;
            }

            carHorsepowerSum /= catalogue.Car.Count();
            truckHorsePowerSum /= catalogue.Truck.Count();

            PrintAvgHorsepower(carHorsepowerSum, truckHorsePowerSum); 
        }

        private static void PrintAvgHorsepower(double carHorsepowerSum, double truckHorsePowerSum)
        {
            string carMessage = "Cars have average horsepower of: 0.00.";
            string truckMessage = "Trucks have average horsepower of: 0.00.";

            if (truckHorsePowerSum > 0 && carHorsepowerSum > 0)
            {
                carMessage = $"Cars have average horsepower of: {carHorsepowerSum:F2}.";
                truckMessage = $"Trucks have average horsepower of: {truckHorsePowerSum:F2}.";
            }
            else if(carHorsepowerSum > 0 && truckHorsePowerSum != 0)
            {
                carMessage = $"Cars have average horsepower of: {carHorsepowerSum:F2}.";
            }
            else
            {
                truckMessage = $"Trucks have average horsepower of: {truckHorsePowerSum:F2}.";
            }

            Console.WriteLine(carMessage);
            Console.WriteLine(truckMessage);
        }
    }
}
