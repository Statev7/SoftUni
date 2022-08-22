namespace BasicWebServer.HTTP
{
    using System;

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
    }
}
