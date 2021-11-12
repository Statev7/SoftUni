namespace CommandPattern
{
    using CommandPattern.Core;
    using CommandPattern.Core.Contracts;
    using CommandPattern.Models;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
