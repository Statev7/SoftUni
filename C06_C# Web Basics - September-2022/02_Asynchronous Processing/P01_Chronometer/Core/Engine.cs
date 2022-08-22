namespace P01_Chronometer.Core
{
    using System;

    using P01_Chronometer.Common;
    using P01_Chronometer.Core.Contracts;

    internal class Engine : IEngine
    {
        public void Run()
        {
            IChronometer chonometer = new Chronometer();
            CommandInterpreter commandInterpreter = new CommandInterpreter(chonometer);

            try
            {
                while (GlobalContants.IsAppRun)
                {
                    string input = Console.ReadLine();
                    commandInterpreter.ProcessCommand(input);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
