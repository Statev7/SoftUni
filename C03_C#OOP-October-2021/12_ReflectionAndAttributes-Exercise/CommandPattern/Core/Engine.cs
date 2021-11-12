namespace CommandPattern.Core
{
    using System;

    using CommandPattern.Core.Contracts;

    public class Engine :  IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                try
                {
                    var result = this.commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
