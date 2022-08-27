namespace BasicWebServer.Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Sessions;
    using BasicWebServer.Responses.ContentResponses;

    public class StartUp
    {

        private const string HtmlForm = @"<form action='/HTML' method='Post'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
            </form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
            <input type='submit' value ='Download Sites Content' /> 
            </form>";

        private const string FileName = "content.txt";

        private const string LoginForm = @"<form action='/Login' method='POST'>
            Username: <input type='text' name='Username'/>
            Password: <input type='text' name='Password'/>
            <input type='submit' value ='Log In' /> 
            </form>";

        private const string Username = "user";
        private const string Password = "user123";


        public async static Task Main()
        {
            await DownloadSitesAsTextFile(FileName, 
                new string[] { "https://judge.softuni.org/", "https://softuni.org" });

            //HTTPServer server = new HTTPServer(routes => routes
            //    .MapGet("/", new TextResponse("Hello from my cat web server!"))
            //    .MapGet("/HTML", new HtmlResponse(HtmlForm))
            //    .MapPost("/HTML", new HtmlResponse("", AddFormDataAction))
            //    .MapGet("/Content", new HtmlResponse(DownloadForm))
            //    .MapPost("/Content", new TextFileResponse(FileName))
            //    .MapGet("/Cookies", new HtmlResponse("", AddCookiesAction))
            //    .MapGet("/Session", new TextResponse("", DisplaySessionInfoAction))
            //    .MapGet("/Login", new HtmlResponse(LoginForm))
            //    .MapPost("/Login", new HtmlResponse("", LoginAction))
            //    .MapGet("/Logout", new HtmlResponse("", LogoutAction))
            //    .MapGet("/UserProfile", new HtmlResponse("", GetDataAction)));
            
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

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadSitesAsTextFile(url));
            }

            var responses = await Task.WhenAll(downloads);
            var responsesString = string.Join(Environment.NewLine + new string('-', 100), responses);

            await File.WriteAllTextAsync(fileName, responsesString);
        }

        private static async Task<string> DownloadSitesAsTextFile(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static void AddCookiesAction(Request request, Response response)
        {
            bool requestHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);
            string bodyText = string.Empty;

            if (requestHasCookies)
            {
                StringBuilder cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.
                    Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookie set!</h1>";

                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Cat-Cookie", "My-Cat-Value");
            }

            response.Body += bodyText;
        }

        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            bool isSessionExist = request.Session.Contains(Session.SessionCurrentDateKey);
            string bodyText = "Current date stored!";

            if (isSessionExist)
            {
                bodyText = $"Stored data: {request.Session[Session.SessionCurrentDateKey]}";
            }

            response.Body = string.Empty;
            response.Body += bodyText;
        }

        public static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            string bodyText = LoginForm;

            bool isUsernameMatches = request.Form["Username"] == Username;
            bool isPasswordMatches = request.Form["Password"] == Password;

            if (isUsernameMatches && isPasswordMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logged successfully</h3>";
            }

            response.Body = String.Empty;
            response.Body += bodyText;
        }

        public static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = String.Empty;
            response.Body += "<h3>Logged out successfully!</h3>";
        }

        public static void GetDataAction(Request request, Response response)
        {
            string bodyText = "<h3>You should first log in - <a href=\"http://localhost:8080/Login\">Login</h3>";

            bool isAuthenticated = request.Session.Contains(Session.SessionUserKey);
            if (isAuthenticated)
            {
                bodyText = $"<h3>Currently logged-in user is with username '{Username}'</h3>"; 
            }

            response.Body = String.Empty;
            response.Body += bodyText;
        }
    }
}
