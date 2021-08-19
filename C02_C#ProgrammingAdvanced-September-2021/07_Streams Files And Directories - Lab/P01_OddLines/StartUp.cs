namespace P01_OddLines
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                int count = 0;
                string line = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
