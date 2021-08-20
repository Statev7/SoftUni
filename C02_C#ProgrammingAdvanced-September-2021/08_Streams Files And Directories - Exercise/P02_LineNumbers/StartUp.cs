namespace P02_LineNumbers
{
    using System.IO;

    public class StartUp
    {
        const string INPUT_PATH = @"../../../text.txt";
        const string OUTPUT_PATH = @"../../../output.txt";

        public static void Main()
        {
            using (StreamReader reader = new StreamReader(INPUT_PATH))
            {
                using (StreamWriter writer = new StreamWriter(OUTPUT_PATH))
                {
                    int lineCount = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        int letters = CountLetters(line);
                        int marks = CountMarks(line);

                        string result = $"{lineCount}: {line} ({letters})({marks})";
                        writer.WriteLine(result);

                        lineCount++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private static int CountLetters(string line)
        {
            int letterCount = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];
                if (char.IsLetter(current))
                {
                    letterCount++;
                }
            }

            return letterCount;
        }

        private static int CountMarks(string line)
        {
            int marksCount = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];
                if (char.IsPunctuation(current))
                {
                    marksCount++;
                }
            }

            return marksCount;
        }
    }
}
