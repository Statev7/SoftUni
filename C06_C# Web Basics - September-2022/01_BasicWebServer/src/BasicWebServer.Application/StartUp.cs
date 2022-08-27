namespace BasicWebServer.Application
{
    using System.Threading.Tasks;

    using BasicWebServer.Application.Controllers;
    using BasicWebServer.Controllers;

    public class StartUp
    {
        public async static Task Main()
        {
            HTTPServer server = new HTTPServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index("Hello from cats server!"))
                .MapGet<HomeController>("/Redirect", c => c.Redirect("https:softuni.bg"))
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())
                .MapGet<UserController>("/Login", c => c.Login())
                .MapPost<UserController>("/Login", c => c.LogInUser())
                .MapGet<UserController>("/Logout", c => c.Logout())
                .MapGet<UserController>("/UserProfile", c => c.UserProfile()));

            await server.Start();
        }
    }
}
