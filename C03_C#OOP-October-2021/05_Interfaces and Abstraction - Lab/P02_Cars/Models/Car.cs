namespace Cars.Models
{
    using System;

    using Cars.Models.Interfaces;

    public abstract class Car : ICar
    {
        private const string ERROR_MESSAGE = "{0} cannot be null or empty!";
        private const string ENGINE_START_MESSAGE = "Engine start";
        private const string ENGINE_STOP_MESSAGE = "Breaaak!";

        private string model;
        private string color;

        protected Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.Validator(value, nameof(this.Model));

                this.model = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                this.Validator(value, nameof(this.Color));

                this.color = value;
            }
        }

        public string Start()
        {
            return ENGINE_START_MESSAGE;
        }

        public string Stop()
        {
            return ENGINE_STOP_MESSAGE;
        }

        private void Validator(string value, string type)
        {
            bool isInvalid = string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
            if (isInvalid)
            {
                string msg = string.Format(ERROR_MESSAGE, type);
                throw new ArgumentException(msg);
            }
        }
    }
}
