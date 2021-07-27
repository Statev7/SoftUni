namespace P09_NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const int MAX_MILEAGE_VALUE = 100000;
        const int MAX_LITERS_OF_FUEL_VALUE = 75;
        const int MIN_MILEAGE_VALUE = 10000;

        const string COMMAND_TO_STOP = "Stop";

        const string DRIVE_MESSAGE = "{0} driven for {1} kilometers. {2} liters of fuel consumed.";
        const string NOT_ENOUGH_FUEL_ERROR_MESSAGE = "Not enough fuel to make that ride";
        const string SELL_CAR_MESSAGE = "Time to sell the {0}!";
        const string REFUAL_MESSAGE = "{0} refueled with {1} liters";
        const string REVERT_MESSAGE = "{0} mileage decreased by {1} kilometers";
        const string RESULT_MESSAGE = "{0} -> Mileage: {1} kms, Fuel in the tank: {2} lt.";

        public static void Main()
        {
            List<Car> allCars = new List<Car>();
            AddCar(allCars);
            ExecuteCommands(allCars);
        }

        private static void AddCar(List<Car> allCars)
        {
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] arg = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string model = arg[0];
                int mileage = int.Parse(arg[1]);
                int fuel = int.Parse(arg[2]);

                Car car = new Car(model, mileage, fuel);
                allCars.Add(car);
            }
        }

        private static void ExecuteCommands(List<Car> allCars)
        {
            while (true)
            {
                string[] arg = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(allCars);
                    break;
                }

                string command = arg[0];
                string model = arg[1];
                int fuel = 0;

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(arg[2]);
                        fuel = int.Parse(arg[3]);
                        Drive(allCars, model, distance, fuel);
                        break;
                    case "Refuel":
                        fuel = int.Parse(arg[2]);
                        Refuel(allCars, model, fuel);
                        break;
                    case "Revert":
                        int kilometers = int.Parse(arg[2]);
                        Revert(allCars, model, kilometers);
                        break;
                }
            }
        }

        private static void Drive(List<Car> allCars, string model, int distance, int fuel)
        {
            Car car = FindModel(allCars, model);

            bool canDrive = car.Fuel >= fuel;
            if (canDrive)
            {
                car.Fuel -= fuel;
                car.Mileage += distance;
                PrintOperation(string.Format(DRIVE_MESSAGE, model, distance, fuel));

                if (car.Mileage >= MAX_MILEAGE_VALUE)
                {
                    allCars.Remove(car);
                    PrintOperation(string.Format(SELL_CAR_MESSAGE, model));
                }
            }
            else
            {
                PrintOperation(NOT_ENOUGH_FUEL_ERROR_MESSAGE);
            }
        }

        private static void Refuel(List<Car> allCars, string model, int fuel)
        {
            Car car = FindModel(allCars, model);

            bool isTheFuelMoreThatTheMaximum = car.Fuel + fuel > MAX_LITERS_OF_FUEL_VALUE;
            if (isTheFuelMoreThatTheMaximum)
            {
                PrintOperation(string.Format(REFUAL_MESSAGE, model, MAX_LITERS_OF_FUEL_VALUE - car.Fuel));
                car.Fuel = MAX_LITERS_OF_FUEL_VALUE;
            }
            else
            {
                car.Fuel += fuel;
                PrintOperation(string.Format(REFUAL_MESSAGE, model, fuel));
            }
        }

        private static void Revert(List<Car> allCars, string model, int kilometers)
        {
            Car car = FindModel(allCars, model);

            bool isTheMileageLessThatTheMinumum = car.Mileage - kilometers < MIN_MILEAGE_VALUE;
            if (isTheMileageLessThatTheMinumum)
            {
                car.Mileage = MIN_MILEAGE_VALUE;
            }
            else
            {
                car.Mileage -= kilometers;
                PrintOperation(string.Format(REVERT_MESSAGE, model, kilometers));
            }
        }

        private static Car FindModel(List<Car> allCars, string model)
        {
            return allCars
                .Where(x => x.Model == model)
                .SingleOrDefault();
        }

        private static void PrintOperation(string str)
        {
            Console.WriteLine(str);
        }

        private static void PrintResult(List<Car> allCars)
        {
            var orderedCars = allCars
                .OrderByDescending(x => x.Mileage)
                .ThenBy(x => x.Model)
                .ToList();

            foreach (var car in orderedCars)
            {
                Console.WriteLine(string.Format(RESULT_MESSAGE, car.Model, car.Mileage, car.Fuel));
            }
        }
    }

    public class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            this.Model = model;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
        
        public string Model { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
}
