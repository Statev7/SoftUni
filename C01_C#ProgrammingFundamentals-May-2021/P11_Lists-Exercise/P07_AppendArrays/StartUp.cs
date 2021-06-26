namespace P07_AppendArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split( "|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> output = new List<string>();

            for (int listIndex = input.Count - 1; listIndex >= 0; listIndex--)
            {
                string[] array = input[listIndex].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int arrayIndex = 0; arrayIndex < array.Length; arrayIndex++)
                {
                    output.Add(array[arrayIndex]);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
