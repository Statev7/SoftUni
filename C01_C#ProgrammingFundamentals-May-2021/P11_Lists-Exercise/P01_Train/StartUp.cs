namespace P01_Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int maxCapasity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                string command = arguments[0];

                bool isStopCommand = command == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                switch (command)
                {
                    case "Add":
                        int wagonToAdd = int.Parse(arguments[1]);
                        AddWagonWithPassengers(wagons, wagonToAdd); 
                            break;
                    default:
                        int passengersCount = int.Parse(arguments[0]);
                        AddPassengersToWagons(wagons, maxCapasity, passengersCount);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void AddWagonWithPassengers(List<int> wagons, int wagonToAdd)
        {
            wagons.Add(wagonToAdd);
        }

        private static void AddPassengersToWagons(List<int> wagons, int maxCapasity, int passengersCount)
        {
            for (int index = 0; index < wagons.Count; index++)
            {
                bool isItPossibleToFit = wagons[index] + passengersCount <= maxCapasity;
                if (isItPossibleToFit)
                {
                    wagons[index] += passengersCount;
                    break;
                }
            }
        }
    }
}
