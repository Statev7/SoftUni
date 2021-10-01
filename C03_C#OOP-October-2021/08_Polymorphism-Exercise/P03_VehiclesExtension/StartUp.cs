namespace VehiclesExtension
{
    using VehiclesExtension.Core;
    using VehiclesExtension.IO;

    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
