namespace P01_Logger.Models.IOManager
{
    using System.IO;

    using P01_Logger.Models.Contracts;

    public class IOManager : IIOManager
    {
        private string currentPath;

        private string folderName;
        private string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
            :this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;


        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectory()
        {
            var currentDir = Directory.GetCurrentDirectory();

            return currentDir;
        }
    }
}
