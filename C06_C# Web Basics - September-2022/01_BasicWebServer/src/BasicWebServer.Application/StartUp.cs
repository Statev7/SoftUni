﻿namespace BasicWebServer.Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
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

        private const string DownloadForm = @"<form action='/Content' method='POST'>
            <input type='submit' value ='Download Sites Content' /> 
            </form>";

        private const string FileName = "content.txt";

        public async static Task Main()
        {
            await DownloadSitesAsTextFile(FileName, 
                new string[] { "https://judge.softuni.org/", "https://softuni.org" });

            HTTPServer server = new HTTPServer(routes => routes
            .MapGet("/", new TextResponse("Hello from my cat web server!"))
            .MapGet("/HTML", new HtmlResponse(HtmlForm))
            .MapPost("/HTML", new HtmlResponse("", AddFormDataAction))
            .MapGet("/Content", new HtmlResponse(DownloadForm))
            .MapPost("/Content", new TextFileResponse(FileName)));
            
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
    }
}
