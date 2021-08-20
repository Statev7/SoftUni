namespace P05_DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] fileArray = Directory.GetFiles(".", "*.*");

            var dirInfo = new Dictionary<string, Dictionary<string, double>>();

            var directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (var currentFile in allFiles)
            {
                double size = currentFile.Length / 1024d;
                string fileName = currentFile.Name;
                string extension = currentFile.Extension;

                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }

                if (!dirInfo[extension].ContainsKey(fileName))
                {
                    dirInfo[extension].Add(fileName, size);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    + @"/report.txt";

            using (var writer = new StreamWriter(path))
            {
                var sortedDict = dirInfo
                        .OrderByDescending(x => x.Value.Count)
                        .ThenBy(x => x.Key)
                        .ToDictionary(x => x.Key, y => y.Value);

                foreach (var (extension, value) in sortedDict)
                {
                    writer.WriteLine(extension);
                    foreach (var (fileName, size) in value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{fileName} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
