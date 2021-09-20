namespace ShoppingSpree
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
