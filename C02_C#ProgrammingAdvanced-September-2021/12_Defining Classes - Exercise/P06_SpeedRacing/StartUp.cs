namespace P06_SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string COMMAND_TO_END_DRIVE = "End";

        public static void Main()
        {
            List<Car> allCars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                var carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumptionFor1km = double.Parse(carArgs[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                allCars.Add(car);
            }

            string driveArguments = Console.ReadLine();
            while (driveArguments != COMMAND_TO_END_DRIVE)
            {
                var splited = driveArguments
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = splited[1];
                double distance = double.Parse(splited[2]);

                Car car = allCars
                    .Where(x => x.Model == model)
                    .SingleOrDefault();

                car.Drive(distance);

                driveArguments = Console.ReadLine();
            }

            foreach (var car in allCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
