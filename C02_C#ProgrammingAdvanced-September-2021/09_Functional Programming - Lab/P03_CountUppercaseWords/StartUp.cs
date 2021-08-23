namespace P03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] inputText = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            inputText
                .Where(x => char.IsUpper(x[0]))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
