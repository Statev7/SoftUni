namespace Rading
{
    using Rading.Core;
    using Rading.Core.Contracts;
    using Rading.IO;
    using Rading.IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
