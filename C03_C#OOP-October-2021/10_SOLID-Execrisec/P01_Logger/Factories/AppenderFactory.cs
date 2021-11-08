namespace P01_Logger.Factories
{
    using System;

    using P01_Logger.Models.Appenders;
    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Enumerations;
    using P01_Logger.Models.File;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender CreteAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelStr, true, out level);
            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile("\\date\\", "logs.txt");
                appender = new FileAppender(layout, level, file);
            }

            return appender;
        }
    }
}
