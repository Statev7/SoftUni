namespace P01_Chronometer.Commands
{
    using System;
    using System.Text;

    using P01_Chronometer.Commands.Contracts;

    public class LapsCommand : ICommand
    {
        public void Execute(IChronometer chronometer)
        {
            var sb = new StringBuilder();

            if (chronometer.Laps.Count == 0)
            {
                throw new InvalidOperationException("No laps!");
            }

            int count = 0;
            sb.AppendLine("Laps:");

            foreach (var lap in chronometer.Laps)
            {
                sb.AppendLine($"{count++}. {lap}");
            }

            string lapsAsString = sb.ToString().TrimEnd();
            Console.WriteLine(lapsAsString);
        }
    }
}
