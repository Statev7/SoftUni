namespace P02_VowelsCount
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToLower().ToCharArray();
            int result = VowelsInString(input);

            Console.WriteLine(result);
        }

        private static int VowelsInString(char[] str)
        {
            int count = 0;

            for (int index = 0; index < str.Length; index++)
            {
                bool isValid =
                    str[index] == 'a' ||
                    str[index] == 'e' ||
                    str[index] == 'i' ||
                    str[index] == 'o' ||
                    str[index] == 'u';

                if (isValid)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
