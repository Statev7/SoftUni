namespace Shapes.Models
{
    using System;

    using Shapes.Models.Interfaces;

    public class Rectangle : IDrawable
    {
        private const int MIN_SIDE_VALUE = 1;
        private const string SIDE_ERROR_MESSAGE = "{0} cannot be a negative number";

        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
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

        public int Height
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

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }

            DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }


        private void SideValidator(int value, string side)
        {
            if (value < MIN_SIDE_VALUE)
            {
                string msg = string.Format(SIDE_ERROR_MESSAGE, side);
                throw new ArgumentException(msg);
            }
        }
    }
}
