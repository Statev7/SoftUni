namespace BasicWebServer.Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    using BasicWebServer.Application.Models;
    using BasicWebServer.Controllers;
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Cookies;

    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index(string text) => this.Text(text);

        public Response Redirect(string location) => base.Redirect(location);

        public Response Html() => this.View();

        public Response HtmlFormPost()
        {
            string name = this.Request.Form["Name"];
            int age = int.Parse(this.Request.Form["Age"]);

            FormViewModel model = new()
            {
                Name = name,
                Age = age,
            };

            return this.View(model);
        }

        public Response Content() => this.View();


        public Response DownloadContent()
        {
             DownloadSitesAsTextFile(FileName,
               new string[] { "https://judge.softuni.org/", "https://softuni.org" }).Wait();

            return this.File(FileName);
        }

        public Response Cookies()
        {
            bool requestHasCookies = this.Request.Cookies.Any(c => c.Name != HTTP.Sessions.Session.SessionCookieName);

            if (requestHasCookies)
            {
                StringBuilder cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.
                    Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in this.Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                return this.Html(cookieText.ToString());
            }

            CookieCollection cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Cookie-Value");
            cookies.Add("My-Cat-Cookie", "My-Cat-Value");

            return this.Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            string currentDateKey = "CurrentDate";
            bool isSessionExist = this.Request.Session.Contains(currentDateKey);

            if (isSessionExist)
            {
                string currentDate = this.Request.Session[currentDateKey];

                return this.Text($"Stored date: {currentDate}!");
            }

            return this.Text("Current date stored!");
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

            await System.IO.File.WriteAllTextAsync(fileName, responsesString);
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
    }
}
