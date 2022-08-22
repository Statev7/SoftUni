namespace BasicWebServer.Responses.ActionResponses
{
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            :base(StatusCode.BadRequest)
        {

        }
    }
}
