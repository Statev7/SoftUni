namespace P06_StoreBoxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P06_StoreBoxes.Models;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            List<Box> allBoxes = new List<Box>();

            while (true)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                string command = arguments[0];

                bool isStopCommand = command == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string serialNumber = arguments[0];
                string itemName = arguments[1];
                int itemQuantity = int.Parse(arguments[2]);
                decimal itemPrice = decimal.Parse(arguments[3]);

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity);

                allBoxes.Add(box);
            }

            PrintResult(allBoxes);
        }

        private static void PrintResult(List<Box> allBoxes)
        {
            allBoxes = allBoxes
                .OrderByDescending(x => x.BoxPrice)
                .ToList();

            foreach (Box Box in allBoxes)
            {
                Console.Write(Box);
            }
        }
    }
}
