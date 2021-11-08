namespace P01_Logger.Models.Appenders
{
    using System.IO;

    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Enumerations;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile ifile)
        {
            this.Layout = layout;
            this.Level = level;
            this.IFile = ifile;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile IFile { get; private set; }

        public int MessagesAppended { get; private set; }

        public void Apeend(IError error)
        {
            string formattedMessage = this.IFile.Write(this.Layout, error);

            File.AppendAllText(this.IFile.Path, formattedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var result = 
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}, " +
                $"File size {this.IFile.Size}";

            return result.ToString().TrimEnd();
        }
    }
}
