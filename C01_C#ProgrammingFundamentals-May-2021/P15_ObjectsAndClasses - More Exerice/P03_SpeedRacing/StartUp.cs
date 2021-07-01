namespace P03_SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P03_SpeedRacing.Models;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";

        public static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carArguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArguments[0];
                double fuelAmount = double.Parse(carArguments[1]);
                double fuelConsumptionForOneKm = double.Parse(carArguments[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionForOneKm);
                allCars.Add(car);
            }

            while (true)
            {
                string[] driveArguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = driveArguments[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string model = driveArguments[1];
                double distance = double.Parse(driveArguments[2]);

                Car carToDrive = allCars
                    .Where(x => x.Model == model)
                    .SingleOrDefault();

                carToDrive.Drive(distance);
            }

            Console.WriteLine(string.Join(Environment.NewLine, allCars));
        }
    }
}
