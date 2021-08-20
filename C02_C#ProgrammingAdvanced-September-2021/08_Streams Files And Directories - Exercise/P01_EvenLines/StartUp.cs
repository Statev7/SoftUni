namespace P01_EvenLines
{
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class StartUp
    {
        const string PATTERN = @"(\-|\,|\.|\!|\?)";

        const string INPUT_PATH = @"../../../text.txt";
        const string OUTPUT_PATH = @"../../../output.txt";

        public static void Main()
        {
            StreamReader reader = new StreamReader(INPUT_PATH);
            using (reader)
            {
                int count = 0;
                string line = reader.ReadLine();
                StreamWriter writer = new StreamWriter(OUTPUT_PATH);
                using (writer)
                {
                    while (line != null)
                    {
                        if (count % 2 == 0)
                        {
                            Regex regex = new Regex(PATTERN);
                            line = regex.Replace(line, "@");

                            var lineToArray = line.Split(" ").ToArray();
                            string reverse = ReverseAString(lineToArray);

                            writer.WriteLine(reverse);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private static string ReverseAString(string[] line)
        {
            string reverse = string.Empty;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                reverse += line[i] + " ";
            }

            return reverse;
        }
    }
}
