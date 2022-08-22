namespace BasicWebServer.Responses.ActionResponses
{
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public class RedirectResponse : Response
    {
        public RedirectResponse(string location)
            :base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
