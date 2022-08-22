namespace P01_Chronometer.Commands
{
    using System;

    using P01_Chronometer.Commands.Contracts;

    public class LapCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            string lap = chronometer.Lap();
            Console.WriteLine(lap);
        }
    }
}
