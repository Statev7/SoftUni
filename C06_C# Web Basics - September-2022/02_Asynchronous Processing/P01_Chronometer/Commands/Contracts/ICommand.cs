namespace P01_Chronometer.Commands.Contracts
{
    public interface ICommand
    {
        void Execute(IChronometer chronometer);
    }
}
