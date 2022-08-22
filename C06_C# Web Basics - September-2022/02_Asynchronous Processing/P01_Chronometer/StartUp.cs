namespace P01_Chronometer
{
    using P01_Chronometer.Core;
    using P01_Chronometer.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
