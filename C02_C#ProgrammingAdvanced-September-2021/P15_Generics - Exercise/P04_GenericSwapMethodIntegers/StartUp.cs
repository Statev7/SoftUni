namespace P04_GenericSwapMethodIntegers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            var swapArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = swapArg[0];
            int secondIndex = swapArg[1];
            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
