namespace P06_GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var box = new Box();
            var list = new List<double>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var value = double.Parse(Console.ReadLine());
                list.Add(value);
            }

            var compareInput = double.Parse(Console.ReadLine());

            var result = box.GreaterElementsCount(list, compareInput);
            Console.WriteLine(result);
        }
    }
}
