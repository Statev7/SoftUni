namespace P01_ReverseString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            while (true)
            {
                string word = Console.ReadLine();

                bool isStopCommand = word == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string wordBeforeReverse = word;
                word = new string(word.Reverse().ToArray());

                Console.WriteLine($"{wordBeforeReverse} = {word}");
            }
        }
    }
}
