namespace P02_KnightsOfHonor
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<string, string> sirFunc = AddSirToName();
            Action<string> printFunc = Print();

            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                //.Select(x => $"Sir " + x)
                .Select(x => sirFunc(x))
                .ToArray();

            //foreach (var name in inputNames)
            //{
            //    Console.WriteLine(name);
            //}

            foreach (var name in inputNames)
            {
                printFunc(name);
            }

        }

        private static Func<string, string> AddSirToName()
        {
            return x => $"Sir " + x;
        }

        private static Action<string> Print()
        {
            return x => Console.WriteLine(x);
        }
    }
}
