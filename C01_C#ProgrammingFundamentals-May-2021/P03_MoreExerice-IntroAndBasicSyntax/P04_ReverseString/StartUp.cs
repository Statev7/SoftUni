namespace P04_ReverseString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var revesetArray = ReverseArray(input);
            string result = ConvertArrayToString(revesetArray);
            PrintResult(result);
        }

        private static char[] ReverseArray(char[] array)
        {
            Array.Reverse(array);
            return array;
        }

        private static string ConvertArrayToString(char[] array)
        {
            string result = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }

        private static void PrintResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
