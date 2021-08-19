namespace P06_ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMNAD_TO_STOP = "END";
        const string EMPTY_PARK_MESSAGE = "Parking Lot is Empty";

        public static void Main()
        {
            var allCarNumbers = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != COMMNAD_TO_STOP)
            {
                var arg = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = arg[0];
                string carNumber = arg[1];

                switch (command)
                {
                    case "IN": allCarNumbers.Add(carNumber); break;
                    case "OUT": allCarNumbers.Remove(carNumber); break;
                }

                input = Console.ReadLine();
            }

            PrintResult(allCarNumbers);
        }

        private static void PrintResult(HashSet<string> allCarNumbers)
        {
            if (allCarNumbers.Count == 0)
            {
                Console.WriteLine(EMPTY_PARK_MESSAGE);
            }
            else
            {
                foreach (var carNumber in allCarNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
