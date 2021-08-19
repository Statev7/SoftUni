namespace P06_FolderSize
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var files = Directory.GetFiles("../../../TestFolder");

            long size = 0;
            foreach (var filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                 size += fileInfo.Length;
            }

            var sumInMB = (size / 1024.0) / 1024.0;

            File.WriteAllText("../../../result.txt", sumInMB.ToString());
        }
    }
}
