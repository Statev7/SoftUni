namespace P01_ActionPoint
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> func = Print();

            foreach (var item in input)
            {
                func(item);
            }
        }

        static Action<string> Print()
        {
            return x => Console.WriteLine(x);
        }
    }
}
