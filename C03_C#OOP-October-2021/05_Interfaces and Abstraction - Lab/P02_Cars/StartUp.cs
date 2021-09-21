namespace Cars
{
    using System;

    using Cars.Models;
    using Cars.Models.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                ICar seat = new Seat("Leon", "Grey");
                ICar tesla = new Tesla("Model 3", "Red", 2);

                Console.WriteLine(seat.ToString());
                Console.WriteLine(tesla.ToString());

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
