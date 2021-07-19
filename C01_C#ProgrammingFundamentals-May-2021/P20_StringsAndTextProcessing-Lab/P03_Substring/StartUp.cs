namespace P03_Substring
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string removeWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            while (true)
            {
                int index = text.IndexOf(removeWord);
                if (index == -1)
                {
                    break;
                }

                text = text.Remove(index, removeWord.Length);
            }

            Console.WriteLine(text);
        }
    }
}
