namespace P03_WordCount
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string PATTERN = @"[a-z]+";

        public static void Main()
        {
            var allWords = new Dictionary<string, int>();

            StreamReader wordsReader = new StreamReader("../../../words.txt");
            using (wordsReader)
            {
                string[] words = wordsReader.ReadToEnd().Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (allWords.ContainsKey(words[i]) == false)
                    {
                        allWords.Add(words[i], 0);
                    }
                }
            }

            StreamReader readInput = new StreamReader("../../../text.txt");
            using (readInput)
            {
                string inputWords = readInput.ReadToEnd().ToLower();

                Regex regex = new Regex(PATTERN);
                var matches = regex.Matches(inputWords);
                foreach (var word in allWords)
                {
                    string searchWord = word.Key;
                    for (int i = 0; i < matches.Count(); i++)
                    {
                        if (Equals(searchWord, matches[i].ToString()))
                        {
                            allWords[searchWord]++;
                        }
                    }
                }
            }

            StreamWriter writer = new StreamWriter("../../../Output.txt");
            using (writer)
            {
                foreach (var word in allWords
                    .OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
