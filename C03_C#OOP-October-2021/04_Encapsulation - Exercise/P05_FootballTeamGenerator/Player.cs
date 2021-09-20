namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private const int STATS_MIN_VALUE = 0;
        private const int STATS_MAX_VALUE = 100;

        private const string NAME_ERROR_MESSAGE = "A name should not be empty.";
        private const string STATS_ERROR_MESSAGE = "{0} should be between 0 and 100.";

        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                bool isInvalid = string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
                if (isInvalid)
                {
                    throw new ArgumentException(NAME_ERROR_MESSAGE);
                }

                this.name = value;
            }
        }

        public double Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                bool isValid = this.StatsValidator(value);
                if (isValid == false)
                {
                    this.ThrowExeption(nameof(this.Endurance));
                }

                this.endurance = value;
            }
        }

        public double Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                bool isValid = this.StatsValidator(value);
                if (isValid == false)
                {
                    this.ThrowExeption(nameof(this.Sprint));
                }

                this.sprint = value;
            }
        }

        public double Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                bool isValid = this.StatsValidator(value);
                if (isValid == false)
                {
                    this.ThrowExeption(nameof(this.Dribble));
                }

                this.dribble = value;
            }
        }

        public double Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                bool isValid = this.StatsValidator(value);
                if (isValid == false)
                {
                    this.ThrowExeption(nameof(this.Passing));
                }

                this.passing = value;
            }
        }

        public double Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                bool isValid = this.StatsValidator(value);
                if (isValid == false)
                {
                    this.ThrowExeption(nameof(this.Shooting));
                }

                this.shooting = value;
            }
        }

        public int Rating => CalculateRating();

        private int CalculateRating()
        {
            return (int)Math.Round((this.Dribble + this.Endurance + this.Passing + this.Shooting + this.Sprint) / (double)5);
        }

        private bool StatsValidator(double value)
        {
            bool isValid = value >= STATS_MIN_VALUE && value <= STATS_MAX_VALUE;

            return isValid;
        }

        private void ThrowExeption(string statsType)
        {
            throw new ArgumentException(string.Format(STATS_ERROR_MESSAGE, statsType));
        }
    }
}
