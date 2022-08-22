namespace BasicWebServer.Responses.ActionResponses
{
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
           : base(StatusCode.Unauthorized)
        {

        }
    }
}
