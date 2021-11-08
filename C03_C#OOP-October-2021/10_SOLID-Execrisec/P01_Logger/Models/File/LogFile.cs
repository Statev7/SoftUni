namespace P01_Logger.Models.File
{
    using System.IO;
    using System.Linq;

    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.IOManager;

    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
        }

        public string Path => this.IOManager.CurrentFilePath;

        public int Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;
            var date = error.DateTime;
            var message = error.Message;
            var level = error.Level.ToString();

            string formatedMessage = string.Format(format, date, message, level);

            return formatedMessage;
        }

        private int GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            var size = text
                .Where(ch => char.IsLetter(ch))
                .Sum(ch => ch);

            return size;
        }
    }
}
