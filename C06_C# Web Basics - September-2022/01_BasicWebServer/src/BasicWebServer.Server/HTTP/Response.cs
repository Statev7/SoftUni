namespace BasicWebServer.HTTP
{
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
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; }

        public string Body { get; set; }
    }
}
