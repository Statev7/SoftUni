namespace P01_RandomizeWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> strings = Console.ReadLine()
                .Split(" ")
                .ToList();

            Random random = new Random();

            for (int index = 0; index < strings.Count; index++)
            {
                int randomPossion = random.Next(strings.Count);
                string temp = strings[index];
                string swapString = strings[randomPossion];

                strings[index] = swapString;
                strings[randomPossion] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine, strings));
        }
    }
}
