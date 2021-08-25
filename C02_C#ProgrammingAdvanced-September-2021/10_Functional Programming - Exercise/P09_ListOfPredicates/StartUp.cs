namespace P09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var validNumbs = new List<int>();

            for (int num = 1; num <= range; num++)
            {
                bool isBrek = false;
                for (int i = 0; i < deviders.Length; i++)
                {
                    if (num % deviders[i] != 0)
                    {
                        isBrek = true;
                        break;
                    }
                }

                if (isBrek == false)
                {
                    validNumbs.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", validNumbs));
        }
    }
}
