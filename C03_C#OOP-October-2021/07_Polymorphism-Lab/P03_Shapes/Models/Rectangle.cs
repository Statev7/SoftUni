namespace Shapes
{
    using System;

    public class Rectangle : Shape
    {
        private const string SIDE_ERROR_MESSAGE = "{0} cannot be a null or negative.";
        private const int MIN_SIDE_VALUE = 0;

        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.SideValidator(value, nameof(this.Height));

                this.height = value;
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
                this.SideValidator(value, nameof(this.Width));

                this.width = value;
            }
        }

        public override double CalculateArea() => this.Height * this.Width;

        public override double CalculatePerimeter() => 2 * (this.Width + this.Height);

        public override string Draw() => base.Draw() + "Rectangle";

        private void SideValidator(double value, string side)
        {
            if (value <= MIN_SIDE_VALUE)
            {
                string msg = string.Format(SIDE_ERROR_MESSAGE, side);
                throw new ArgumentException(msg);
            }
        }
    }
}
