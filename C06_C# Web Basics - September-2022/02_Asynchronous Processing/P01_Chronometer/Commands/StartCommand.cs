namespace P01_Chronometer.Commands
{
    using System.Threading.Tasks;

    using P01_Chronometer.Commands.Contracts;

    public class StartCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            Task.Run(() =>
            {
                chronometer.Start();
            });
        }
    }
}
