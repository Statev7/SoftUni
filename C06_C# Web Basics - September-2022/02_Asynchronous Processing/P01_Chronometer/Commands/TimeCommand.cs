namespace P01_Chronometer.Commands
{
    using System;

    using P01_Chronometer.Commands.Contracts;

    public class TimeCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            Console.WriteLine(chronometer.GetTime);
        }
    }
}
