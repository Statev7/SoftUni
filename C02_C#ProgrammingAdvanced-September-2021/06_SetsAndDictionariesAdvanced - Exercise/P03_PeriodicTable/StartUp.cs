namespace P03_PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var chemicalElements = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < input.Length; index++)
                {
                    chemicalElements.Add(input[index]);
                }
            }

            foreach (var element in chemicalElements
                .OrderBy(x => x))
            {
                Console.Write(element + " ");
            }
        }
    }
}
