namespace P03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string PATTERN = @"[a-z]+";

        const string WORDS_PATH = @"../../../words.txt";
        const string TEXT_PATH = @"../../../text.txt";
        const string ACTUAL_RESULT_PATH = @"../../../actualResult.txt";
        const string EXPECTED_RESULT_PATH = @"../../../expectedResult.txt";

        public static void Main()
        {
            var keyWords = new Dictionary<string, int>();

            string[] words = File.ReadAllLines(WORDS_PATH);
            for (int i = 0; i < words.Length; i++)
            {
                keyWords.Add(words[i], 0);
            }

            string[] text = File.ReadAllLines(TEXT_PATH);
            for (int i = 0; i < text.Length; i++)
            {
                Regex regex = new Regex(PATTERN);
                var matches = regex.Matches(text[i].ToLower());
                foreach (Match word in matches)
                {
                    if (keyWords.ContainsKey(word.ToString()))
                    {
                        keyWords[word.ToString()]++;
                    }
                }
            }

            var sortedDictionary = keyWords
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            string[] actualResult = new string[keyWords.Count()];
            string[] exectedResult = new string[keyWords.Count()];

            actualResult = AddElementsToArray(keyWords, actualResult);
            exectedResult = AddElementsToArray(sortedDictionary, exectedResult);

            WriteInFile(ACTUAL_RESULT_PATH, actualResult);
            WriteInFile(EXPECTED_RESULT_PATH, exectedResult);
        }

        private static string[] AddElementsToArray(Dictionary<string, int> keyWords, string[] array)
        {
            int index = 0;
            foreach (var word in keyWords)
            {
                array[index] = $"{word.Key} - {word.Value}";
                index++;
            }

            return array;
        }

        private static void WriteInFile(string path, string[] array)
        {
            File.WriteAllLines(path, array);
        }
    }
}
