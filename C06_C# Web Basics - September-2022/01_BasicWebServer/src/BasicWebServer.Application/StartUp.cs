namespace BasicWebServer.Application
{
    using System.Threading.Tasks;

    using BasicWebServer.Responses.ActionResponses;
    using BasicWebServer.Responses.ContentResponses;

    public class StartUp
    {

        public async static Task Main()
        {
            HTTPServer server = new HTTPServer(routes => routes
            .MapGet("/", new TextResponse("Hello from my cat web server!"))
            .Map("/Cats", HTTP.Enums.HTTPMethod.Get, new HtmlResponse("<h1>Hello from map method</h1>"))
            .MapGet("/SoftUni", new RedirectResponse("https://softuni.bg")));

            await server.Start();
        }
    }
}
