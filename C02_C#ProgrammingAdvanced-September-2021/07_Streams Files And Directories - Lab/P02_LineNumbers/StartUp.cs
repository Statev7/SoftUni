namespace P02_LineNumbers
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                StreamWriter writer = new StreamWriter("../../../output.txt");
                using (writer)
                {
                    int lineCount = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{lineCount}. {line}");

                        lineCount++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
