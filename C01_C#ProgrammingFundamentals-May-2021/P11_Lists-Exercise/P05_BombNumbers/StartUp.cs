namespace P05_BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> specialNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int bombCordination = specialNumbers[0];
            int bombRange = specialNumbers[1];

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] == bombCordination)
                {
                    for (int i = 0; i < bombRange; i++)
                    {
                        int indexToRemove = index - 1;

                        bool isLeftSideValid = indexToRemove >= 0;
                        if (isLeftSideValid)
                        {
                            numbers.RemoveAt(indexToRemove);
                            index -= 1;
                        }

                        indexToRemove = index + 1;

                        bool isRightSideValid = numbers.Count > indexToRemove;
                        if (isRightSideValid)
                        {
                            numbers.RemoveAt(indexToRemove);
                        }
                    }

                    numbers.Remove(bombCordination);
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
