namespace P03_Calculations
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string command = Console.ReadLine().ToLower();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            ChoseAOperation(command, firstNumber, secondNumber);
        }

        private static void ChoseAOperation(string command, int firstNumber, int secondNumber)
        {
            int result = 0;

            switch (command)
            {
                case "add": result = Add(firstNumber, secondNumber); break;
                case "subtract": result = Substact(firstNumber, secondNumber); break;
                case "multiply": result = Multiply(firstNumber, secondNumber); break;
                case "divide": result = Divide(firstNumber, secondNumber); break;
            }

            PrintResult(result);
        }

        private static int Add(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }

        private static int Substact(int firstNumber, int secondNumber)
        {
            int sum = firstNumber - secondNumber;
            return sum;
        }

        private static int Multiply(int firstNumber, int secondNumber)
        {
            int sum = firstNumber * secondNumber;
            return sum;
        }

        private static int Divide(int firstNumber, int secondNumber)
        {
            int sum = firstNumber / secondNumber;
            return sum;
        }

        private static void PrintResult(int result)
        {
            Console.WriteLine(result);
        }
    }
}
