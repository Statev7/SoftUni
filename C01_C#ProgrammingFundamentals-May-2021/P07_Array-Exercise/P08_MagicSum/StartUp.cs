namespace P08_MagicSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int inputSum = int.Parse(Console.ReadLine());

            for (int firstIndex = 0; firstIndex < inputArray.Length; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < inputArray.Length; secondIndex++)
                {
                    int sumOfDigits = inputArray[firstIndex] + inputArray[secondIndex];

                    if (sumOfDigits == inputSum)
                    {
                        Console.Write($"{inputArray[firstIndex]} {inputArray[secondIndex]}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
