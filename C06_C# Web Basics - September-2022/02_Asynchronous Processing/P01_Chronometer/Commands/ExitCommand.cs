namespace P01_Chronometer.Commands
{
    using P01_Chronometer.Commands.Contracts;
    using P01_Chronometer.Common;

    internal class ExitCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            chronometer.Stop();
            GlobalContants.IsAppRun = false;
        }
    }
}
