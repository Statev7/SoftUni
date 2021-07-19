namespace P04_TextFilter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                int lenght = word.Length;

                text = text.Replace(word, new string('*', lenght));
            }

            Console.WriteLine(text);
        }
    }
}
