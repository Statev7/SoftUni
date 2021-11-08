namespace P01_Logger.Factories
{
    using System;

    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Enumerations;
    using P01_Logger.Models.Errors;

    public class ErrorFactory
    {
        public IError CreateError(string date, string message, string levelStr)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelStr, true, out level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            IError error = new Error(date, message, level);

            return error;
        }
    }
}
