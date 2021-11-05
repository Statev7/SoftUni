namespace P05_ConvertToDouble
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var str = Console.ReadLine();

            try
            {
                var number = Convert.ToDouble(str);
                Console.WriteLine(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
