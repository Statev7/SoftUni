namespace P07_PredicateForNames
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> predicate = n => n.Length <= lenght;
            Print(words, predicate);
        }

        private static void Print(string[] array, Predicate<string> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
