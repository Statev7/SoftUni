namespace P06_MiddleCharacters
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            string result = string.Empty;
            result = GetMiddleCharacter(input);

            Console.WriteLine(result);
        }

        private static string GetMiddleCharacter(char[] input)
        {
            string result;
            if (input.Length % 2 == 1)
            {
                result = MiddleCharacterInOddLenght(input);
            }
            else
            {
                result = MiddleCharacterInEvenLenght(input);
            }

            return result;
        }

        private static string MiddleCharacterInOddLenght(char[] input)
        {
            int index = input.Length / 2;
            string result = input[index].ToString();

            return result;
        }

        private static string MiddleCharacterInEvenLenght(char[] input)
        {
            string result = string.Empty;
            result = input[input.Length / 2 - 1].ToString() + input[input.Length / 2].ToString();

            return result;
        }
    }
}
