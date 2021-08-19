namespace P04_MergeFiles
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            StreamReader readFirstFile = new StreamReader("../../../FileOne.txt");
            StreamReader readSecondFile = new StreamReader("../../../FileTwo.txt");
            StreamWriter writer = new StreamWriter("../../../Output.txt");

            using (readFirstFile)
            {
                using (readSecondFile)
                {
                    string firstLine = readFirstFile.ReadLine();
                    string secondLine = readSecondFile.ReadLine();

                    using (writer)
                    {
                        while (firstLine != null && secondLine != null)
                        {
                            writer.WriteLine(firstLine);
                            writer.WriteLine(secondLine);

                            firstLine = readFirstFile.ReadLine();
                            secondLine = readSecondFile.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
