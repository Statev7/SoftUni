namespace P02_RepeatString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            foreach (var word in text)
            {
                for (int index = 0; index < word.Length; index++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
