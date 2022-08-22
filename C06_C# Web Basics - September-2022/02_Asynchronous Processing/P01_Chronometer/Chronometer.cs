namespace P01_Chronometer
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        private const string Format = @"mm\:ss\.ffff";

        private readonly Stopwatch stopwatch;
        private readonly ICollection<string> laps;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => this.stopwatch.Elapsed.ToString(Format);

        public IReadOnlyCollection<string> Laps => (IReadOnlyCollection<string>)this.laps;

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Reset()
        {
            this.stopwatch.Restart();
            this.laps.Clear();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        public string Lap()
        {
            string lap = this.GetTime;

            this.laps.Add(lap);
            return lap;
        }
    }
}
