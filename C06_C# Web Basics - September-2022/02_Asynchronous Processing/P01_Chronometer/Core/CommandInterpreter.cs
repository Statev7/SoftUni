namespace P01_Chronometer.Core
{
    using P01_Chronometer.Commands.Contracts;
    using P01_Chronometer.Factories;
    using P01_Chronometer.Factories.Contracts;

    public class CommandInterpreter 
    {
        private readonly IChronometer chronoometer;
        private readonly IFactory<ICommand> factory;

        public CommandInterpreter(IChronometer chronometer)
        {
            this.chronoometer = chronometer;
            this.factory = new CommandFactory();
        }

        public void ProcessCommand(string input)
        {
            ICommand command = this.factory.Create(input);
            command.Execute(this.chronoometer);
        }
    }
}
