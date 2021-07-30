namespace P03_SimpleCalculator
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>();

            for (int index = input.Length - 1; index >= 0; index--)
            {
                stack.Push(input[index]);
            }

            while (stack.Count != 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                int result = 0;

                switch (operation)
                {
                    case "-": result = Subtraction(firstNumber, secondNumber); break;
                    case "+": result = Addition(firstNumber, secondNumber); break;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Peek());
        }

        private static int Subtraction(int firstNumber, int secondNumber)
        {
            int sum = firstNumber - secondNumber;
            return sum;
        }

        private static int Addition(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }
    }
}
