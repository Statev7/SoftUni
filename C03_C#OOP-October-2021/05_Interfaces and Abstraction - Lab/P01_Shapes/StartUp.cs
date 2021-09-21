namespace Shapes
{
    using System;

    using Shapes.Models;
    using Shapes.Models.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var radius = int.Parse(Console.ReadLine());
                IDrawable circle = new Circle(radius);

                var width = int.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                IDrawable rect = new Rectangle(width, height);

                circle.Draw();
                rect.Draw();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
