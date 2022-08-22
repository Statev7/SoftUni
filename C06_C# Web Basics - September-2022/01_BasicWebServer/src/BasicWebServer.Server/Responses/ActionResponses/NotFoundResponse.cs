namespace BasicWebServer.Responses.ActionResponses
{
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
           : base(StatusCode.NotFound)
        {

        }
    }
}
