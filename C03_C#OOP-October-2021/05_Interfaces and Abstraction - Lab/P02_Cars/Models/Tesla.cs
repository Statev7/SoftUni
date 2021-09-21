namespace Cars.Models
{
    using System;
    using System.Text;

    using Cars.Models.Interfaces;

    public class Tesla : Car, IElectricCar
    {
        private const string BATTERY_ERROR_MESSAGE = "The battery cannot be negative!";
        private const int MIN_BATTERY_COUNT_VALUE = 1;

        private int battery;

        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery
        {
            get
            {
                return this.battery;
            }
            private set
            {
                bool isInvalid = value < MIN_BATTERY_COUNT_VALUE;
                if (isInvalid)
                {
                    throw new ArgumentException(BATTERY_ERROR_MESSAGE);
                }

                this.battery = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {nameof(Tesla)} {this.Model}");
            sb.AppendLine(this.Start());
            sb.Append(this.Stop());

            return sb.ToString();
        }
    }
}
