namespace P04_CaesarCipher
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char[] text = Console.ReadLine().ToCharArray();
            int charNumber = 0;
            string result = string.Empty;

            for (int index = 0; index < text.Length; index++)
            {
                charNumber = (int)text[index] + 3;
                result += (char)charNumber;
            }

            Console.WriteLine(result);
        }
    }
}
