namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private const string RADIUS_ERROR_MESSAGE = "Radius cannot be a null or negative.";
        private const double RADIUS_MIN_VALUE = 0;

        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                this.RadiusValidator(value);

                this.radius = value;
            }
        }


        public override double CalculateArea() => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override string Draw() => base.Draw() + "Circle";

        private void RadiusValidator(double value)
        {
            if (value <= RADIUS_MIN_VALUE)
            {
                throw new ArgumentException(RADIUS_ERROR_MESSAGE);
            }
        }
    }
}
