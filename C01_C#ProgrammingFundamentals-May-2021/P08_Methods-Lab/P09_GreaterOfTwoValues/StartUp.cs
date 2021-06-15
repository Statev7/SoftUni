namespace P09_GreaterOfTwoValues
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string valueType = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            ChoseType(valueType, firstValue, secondValue);
        }

        private static void ChoseType(string valueType, string firstValue, string secondValue)
        {
            switch (valueType)
            {
                case "string": GetMax(firstValue, secondValue); break;
                case "int":
                    int firstValueAfterIntParse = int.Parse(firstValue);
                    int secondValueAfterIntParse = int.Parse(secondValue);
                    GetMax(firstValueAfterIntParse, secondValueAfterIntParse);
                    break;
                case "char":
                    char firstValueAfterCharParse = char.Parse(firstValue);
                    char secondValueAfterCharParse = char.Parse(secondValue);
                    GetMax(firstValueAfterCharParse, secondValueAfterCharParse);
                    break;
            }
        }

        private static void GetMax(string firstString, string secondString)
        {
            string result = firstString;

            int biggestString = string.Compare(firstString, secondString);

            if (biggestString == -1)
            {
                result = secondString;
            }

            PrintResult(result);
        }

        private static void GetMax(int firstNumber, int secondNumber)
        {
            int result = Math.Max(firstNumber, secondNumber);

            PrintResult(result);
        }

        private static void GetMax(char firstChar, char secondChar)
        {
            char result = firstChar;

            if (secondChar > firstChar)
            {
                result = secondChar;
            }

            PrintResult(result);
        }

        private static void PrintResult<T>(T result)
        {
            Console.WriteLine(result);
        }
    }
}
