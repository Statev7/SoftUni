namespace Shapes.Models
{
    using System;

    using Shapes.Models.Interfaces;

    public class Circle : IDrawable
    {
        private const int MIN_RADIUS_VALUE = 1;
        private const string INVALID_RADIUS_ERROR_MESSAGE = "The radius cannot be negative number!";

        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                bool isInvalid = value < MIN_RADIUS_VALUE;
                if (isInvalid)
                {
                    throw new ArgumentException(INVALID_RADIUS_ERROR_MESSAGE);
                }

                this.radius = value;
            }
        }

        public void Draw()
        {
            var rIn = this.radius - 0.4;
            var rOut = this.radius + 0.4;
            for (var y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    var value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
