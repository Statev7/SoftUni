namespace P01_Logger.Models.Errors
{
    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Enumerations;

    public class Error : IError
    {
        public Error(string dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public string DateTime { get; private set; }

        public string Message { get; private set; }

        public Level Level { get; private set; }
    }
}
