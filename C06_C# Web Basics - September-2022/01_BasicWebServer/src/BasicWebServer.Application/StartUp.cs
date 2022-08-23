namespace BasicWebServer.Application
{
    using System;
    using System.Threading.Tasks;

    using BasicWebServer.HTTP;
    using BasicWebServer.Responses.ActionResponses;
    using BasicWebServer.Responses.ContentResponses;

    public class StartUp
    {

        private const string HtmlForm = @"<form action='/HTML' method='Post'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
            </form>";


        public async static Task Main()
        {
            HTTPServer server = new HTTPServer(routes => routes
            .MapGet("/", new TextResponse("Hello from my cat web server!"))
            .MapGet("/HTML", new HtmlResponse(HtmlForm))
            .MapPost("/HTML", new HtmlResponse("", AddFormDataAction)));
            
            await server.Start();
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = String.Empty;

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"<h1>{key} - {value}</h1>";
                response.Body += Environment.NewLine;
            }
        }
    }
}
