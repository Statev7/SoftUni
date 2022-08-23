namespace BasicWebServer.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using BasicWebServer.HTTP.Enums;
    using BasicWebServer.Responses.ContentResponses;

    public class Request
    {
        public Request()
        {
            this.Form = new Dictionary<string, string>();
        }

        public string Url { get; set; }

        public HTTPMethod HTTPMethod { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string requestAsString)
        {
            string[] lines = requestAsString.Split("\r\n");

            string[] startLine = lines[0].Split(' ');

            HTTPMethod httpMethod = ParseMethod(startLine[0]);
            string url = startLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            string[] bodyLines = lines.Skip(headers.Count + 2).ToArray();
            string body = string.Join("\r\n", bodyLines);

            Dictionary<string, string> form = ParseForm(headers, body);

            Request request = new()
            {
                Url = url,
                HTTPMethod = httpMethod,
                Headers = headers,
                Body = body,
                Form = form
            };

            return request;
        }

        private static HTTPMethod ParseMethod(string httpMethod)
        {
            bool isMethodValid = Enum.TryParse(typeof(HTTPMethod), httpMethod, true, out object method);
            if (!isMethodValid)
            {
                throw new InvalidOperationException($"Method '{httpMethod}' is not supported!");
            }

            return (HTTPMethod)method;
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            HeaderCollection headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {

                if (string.IsNullOrEmpty(headerLine)) // no more headers
                {
                    break;
                }

                string[] headerParts = headerLine.Split(':', 2);
                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid!");
                }

                string headerName = headerParts[0];
                string headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            Dictionary<string, string> formCollection = new();

            if (headers.Contains(Header.ContentType)
                && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                Dictionary<string, string> parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
            => HttpUtility.UrlDecode(bodyLines)
            .Split('&')
            .Select(part => part.Split('='))
            .Where(part => part.Length == 2)
            .ToDictionary(
                part => part[0],
                part => part[1],
                StringComparer.InvariantCultureIgnoreCase);
    }
}
