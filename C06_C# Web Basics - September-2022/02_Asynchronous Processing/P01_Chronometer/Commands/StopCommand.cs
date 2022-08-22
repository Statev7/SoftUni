namespace P01_Chronometer.Commands
{
    using P01_Chronometer.Commands.Contracts;

    public class StopCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            chronometer.Stop();
        }
    }
}
