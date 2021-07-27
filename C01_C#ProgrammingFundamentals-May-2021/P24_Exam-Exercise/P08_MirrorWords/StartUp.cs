namespace P08_MirrorWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string HIDDEN_WORDS_PATTERN = @"([@]|[#])(?<first>[A-Za-z]{3,})\1{2}(?<second>[A-Za-z]{3,})\1";

        const string WORDS_PAIRS_FOUND_MESSAGE = "{0} word pairs found!";
        const string WORDS_PAIRS_NOT_FOUND_MESSAGE = "No word pairs found!";
        const string MIRROR_WORDS_FOUND_MESSAGE = "The mirror words are:";
        const string MIRROR_WORDS_NOT_FOUND_MESSAGE = "No mirror words!";

        public static void Main()
        {
            string text = Console.ReadLine();
            List<string> mirrorWords = new List<string>();

            Regex regex = new Regex(HIDDEN_WORDS_PATTERN);
            var matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                PrintMessage(string.Format(WORDS_PAIRS_FOUND_MESSAGE, matches.Count));

                int count = CountMirrorWords(mirrorWords, matches);
                if (count > 0)
                {
                    PrintMessage(MIRROR_WORDS_FOUND_MESSAGE);
                    PrintMessage(string.Join(", ", mirrorWords));
                }
                else
                {
                    PrintMessage(MIRROR_WORDS_NOT_FOUND_MESSAGE);
                }
            }
            else
            {
                PrintMessage(WORDS_PAIRS_NOT_FOUND_MESSAGE);
                PrintMessage(MIRROR_WORDS_NOT_FOUND_MESSAGE);
            }
        }

        private static int CountMirrorWords(List<string> mirrorWords, MatchCollection matches)
        {
            int count = 0;
            foreach (Match word in matches)
            {
                string firstWord = word.Groups["first"].Value;
                string second = word.Groups["second"].Value;

                string revestedWordAsString = ReveseWord(firstWord);
                if (revestedWordAsString == second)
                {
                    count++;
                    string mirrorWord = $"{firstWord} <=> {second}";
                    mirrorWords.Add(mirrorWord);
                }
            }

            return count;
        }

        private static string ReveseWord(string firstWord)
        {
            char[] reversedWord = firstWord.Reverse().ToArray();
            string revestedWordAsString = string.Empty;

            for (int index = 0; index < reversedWord.Length; index++)
            {
                revestedWordAsString += reversedWord[index];
            }

            return revestedWordAsString;
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
