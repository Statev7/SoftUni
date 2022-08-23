namespace BasicWebServer.HTTP
{
    using System;
    using System.Text;

    using BasicWebServer.HTTP.Enums;

    public class Response
    {
        private Response()
        {
            this.Headers = new HeaderCollection();
        }

        public Response(StatusCode statusCode)
            :this()
        {
            this.StatusCode = statusCode;

            this.Headers.Add(Header.Server, "My Cat Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow.ToString("r")}");
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; }

        public string Body { get; set; }

        public Action<Request, Response> PreRenderAction { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                sb.AppendLine($"{header}");
            }

            sb.AppendLine(string.Empty);

            if (!string.IsNullOrEmpty(this.Body))
            {
                sb.AppendLine(this.Body);
            }

            return sb.ToString(); 
        }
    }
}
