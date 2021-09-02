namespace P05_GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var box = new Box();
            var list = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();
                list.Add(value);
            }

            var compareInput = Console.ReadLine();

            var result = box.GreaterElementsCount(list, compareInput);
            Console.WriteLine(result);
        }
    }
}
