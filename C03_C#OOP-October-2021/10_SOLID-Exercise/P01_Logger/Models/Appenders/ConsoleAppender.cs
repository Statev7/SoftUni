namespace P01_Logger.Models.Appenders
{
    using System;

    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Enumerations;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public int MessagesAppended { get; private set; }

        public void Apeend(IError error)
        {
            var format = this.Layout.Format;
            var date = error.DateTime;
            var message = error.Message;
            var level = error.Level.ToString();

            string formatedMessage = string.Format(format, date, message, level);
            Console.WriteLine(formatedMessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}";

            return result.ToString().TrimEnd();
        }
    }
}
