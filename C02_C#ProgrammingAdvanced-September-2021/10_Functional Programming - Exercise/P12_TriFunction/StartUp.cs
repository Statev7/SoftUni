namespace P12_TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int targetSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> equalFunc = IsEqual;
            Func<string[], int, Func<string, int, bool>, string> firstValidName = 
                (arr, targetSum, equalFunc) => arr.FirstOrDefault(name => equalFunc(name, targetSum));

            Console.WriteLine(firstValidName(names, targetSum, equalFunc));
        }

        private static bool IsEqual(string name, int inputNumber)
        {
            int ascciSum = 0;
            for (int i = 0; i < name.Length; i++)
            {
                ascciSum += (int)name[i];
            }

            return ascciSum >= inputNumber;
        }
    }
}
