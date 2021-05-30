namespace P06_TriplesOfLatinLetters
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char firstChar = (char)('a' + i);

                for (int j = 0; j < n; j++)
                {
                    char secondChar = (char)('a' + j);

                    for (int k = 0; k < n; k++)
                    {
                        char thirdChar = (char)('a' + k);

                        result = firstChar.ToString() + secondChar.ToString() + thirdChar.ToString();

                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
