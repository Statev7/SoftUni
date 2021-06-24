namespace P03_Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Craft!";

        public static void Main()
        {
            List<string> inventory = Console.ReadLine().Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);

                bool isValid = input[0] == COMMAND_TO_STOP;
                if (isValid)
                {
                    break;
                }

                string command = input[0];
                string item = input[1];

                switch (command)
                {
                    case "Collect": Collect(ref inventory, item); break;
                    case "Drop": Drop(ref inventory, item); break;
                    case "Combine": 
                        string combineteItems = input[2]; 
                        Combine(ref inventory, combineteItems); 
                        break;
                    case "Renew": Renew(ref inventory, item); break;
                }
            }

            PrintResult(inventory);
        }

        private static void Collect(ref List<string> inventory, string item)
        {
            bool isItemAlreadyExist = IsItemExist(inventory, item);
            if (!isItemAlreadyExist)
            {
                inventory.Add(item);
            }
        }

        private static void Drop(ref List<string> inventory, string item)
        {
            bool isItemExist = IsItemExist(inventory, item);
            if (isItemExist)
            {
                inventory.Remove(item);
            }
        }

        private static void Combine(ref List<string> inventory, string combinatedItems)
        {
            string[] arguments = combinatedItems.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string oldItem = arguments[0];
            string newItem = arguments[1];

            bool isOldItemExist = IsItemExist(inventory, oldItem);
            if (isOldItemExist)
            {
                int intex = inventory.IndexOf(oldItem);
                inventory.Insert(intex + 1, newItem);
            }
        }

        private static void Renew(ref List<string> inventory, string item)
        {
            string[] itemToCheck = item.Split(new[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);
            string itemAsString = itemToCheck[0];

            bool isChangePossible = IsItemExist(inventory, itemAsString);
            if (isChangePossible)
            {
                inventory.Remove(itemAsString);
                inventory.Add(itemAsString);
            }
        }

        private static bool IsItemExist(List<string> inventory, string item)
        {
            bool isExist = inventory.Contains(item);

            return isExist;
        }

        private static void PrintResult(List<string> inventory)
        {
            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
