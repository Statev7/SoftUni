namespace P01_Lootbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const int NEED_SUM_FOR_EPIC_LOOT = 100;
        private const string FIRST_BOX_EMPTY_MESSAGE = "First lootbox is empty";
        private const string SECOND_BOX_EMPTY_MESSAGE = "Second lootbox is empty";
        private const string POOR_LOOT_MESSAGE = "Your loot was poor... Value: {0}";
        private const string EPIC_LOOT_MESSAGE = "Your loot was epic! Value: {0}";

        public static void Main()
        {
            var firstBoxDate = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var secondBoxDate = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstBox = new Queue<int>(firstBoxDate);
            var secondBox = new Stack<int>(secondBoxDate);
            var sum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                bool isEven = (firstBox.Peek() + secondBox.Peek()) % 2 == 0;
                if (isEven)
                {
                    sum += firstBox.Dequeue() + secondBox.Pop();
                }
                else
                {
                    var element = secondBox.Pop();
                    firstBox.Enqueue(element);
                }
            }

            string emptyBoxMessage = FIRST_BOX_EMPTY_MESSAGE;
            string lootMessage = string.Format(POOR_LOOT_MESSAGE, sum);

            if (secondBox.Count == 0)
            {
                emptyBoxMessage = SECOND_BOX_EMPTY_MESSAGE;
            }
            if (sum >= NEED_SUM_FOR_EPIC_LOOT)
            {
                lootMessage = string.Format(EPIC_LOOT_MESSAGE, sum);
            }

            PrintResult(emptyBoxMessage);
            PrintResult(lootMessage);
        }

        private static void PrintResult(string str)
        {
            Console.WriteLine(str);
        }
    }
}
