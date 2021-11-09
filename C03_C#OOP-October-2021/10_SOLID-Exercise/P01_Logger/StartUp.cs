namespace P01_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P01_Logger.Core;
    using P01_Logger.Core.Contracts;
    using P01_Logger.Factories;
    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Loggers;

    public class StartUp
    {
        public static void Main()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            AddAppender(appendersCount, appenders);

            ILogger logger = new Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();

        }

        private static void AddAppender(int appendersCount, ICollection<IAppender> appenders)
        {
            var appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                var appenderrsArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var appenderType = appenderrsArgs[0];
                var layoutType = appenderrsArgs[1];
                var level = "INFO";

                if (appenderrsArgs.Length == 3)
                {
                    level = appenderrsArgs[2];
                }

                IAppender appender = appenderFactory.CreteAppender(appenderType, layoutType, level);
                appenders.Add(appender);
            }
        }
    }
}
