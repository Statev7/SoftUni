namespace P02_StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<int> numbers = new Stack<int>();
            Add(numbers, input);

            while (true)
            {
                string[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0].ToLower() == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintSum(numbers);
                    break;
                }

                string command = arguments[0].ToLower();
                arguments = arguments.Skip(1).ToArray();
                switch (command)
                {
                    case "add": Add(numbers, arguments);  break;
                    case "remove": Remove(numbers, int.Parse(arguments[0])); break;
                }
            }
        }

        private static void Add(Stack<int> numbers, string[] numbersToAdd)
        {
            for (int i = 0; i < numbersToAdd.Length; i++)
            {
                numbers.Push(int.Parse(numbersToAdd[i]));
            }
        }

        private static void Remove(Stack<int> numbers, int count)
        {
            bool isValid = numbers.Count >= count;
            if (isValid)
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Pop();
                }
            }
        }

        private static void PrintSum(Stack<int> numbers)
        {
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
