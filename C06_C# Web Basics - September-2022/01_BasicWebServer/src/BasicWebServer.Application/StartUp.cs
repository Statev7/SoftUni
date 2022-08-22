namespace BasicWebServer.Application
{
    using System.Threading.Tasks;

    public class StartUp
    {
        public async static Task Main()
        {
            HTTPServer server = new HTTPServer("127.0.0.1", 8080);
            await server.Start();
        }
    }
}
