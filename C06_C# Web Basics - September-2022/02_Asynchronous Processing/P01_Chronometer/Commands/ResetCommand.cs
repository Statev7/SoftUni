namespace P01_Chronometer.Commands
{
    using P01_Chronometer.Commands.Contracts;

    public class ResetCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            chronometer.Reset();
        }
    }
}
