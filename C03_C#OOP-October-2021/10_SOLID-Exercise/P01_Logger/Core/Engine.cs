namespace P01_Logger.Core
{
    using System;
    using System.Linq;

    using P01_Logger.Core.Contracts;
    using P01_Logger.Factories;
    using P01_Logger.Models.Contracts;

    public class Engine : IEngine
    {
        private const string COMMAND_TO_END_READ = "END";

        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            :this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != COMMAND_TO_END_READ)
            {
                var inputArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var level = inputArgs[0];
                var date = inputArgs[1];
                var message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.CreateError(date, message, level);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
