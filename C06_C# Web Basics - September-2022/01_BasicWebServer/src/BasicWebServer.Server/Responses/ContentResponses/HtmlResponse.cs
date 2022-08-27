namespace BasicWebServer.Responses.ContentResponses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content)
            :base(content, ContentType.HtmlText)
        {

        }
    }
}
