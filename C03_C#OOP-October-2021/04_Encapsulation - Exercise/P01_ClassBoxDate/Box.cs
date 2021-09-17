namespace ClassBoxDate
{
    using System;
    using System.Text;

    public class Box
    {
        private const int MIN_SIDE_VALUE = 0;

        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get
            {
                return this.lenght;
            }
            private set
            {
                if (value <= MIN_SIDE_VALUE)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.lenght = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= MIN_SIDE_VALUE)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= MIN_SIDE_VALUE)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double sum = 2 * (this.Lenght * this.Width) + 2 * (this.Lenght * this.Height) + 2 * (this.Width * this.Height);

            return sum;
        }

        public double CalculateLateralSurfaceArea()
        {
            double sum = 2 * (this.Lenght * this.Height) + 2 * (this.Width * this.Height);

            return sum;
        }

        public double CalculateVolume()
        {
            double sum = this.Lenght * this.Height * this.Width;

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():F2}");
            sb.Append($"Volume - {this.CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
