namespace BasicWebServer.Responses.ContentResponses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content)
            :base(content, ContentType.PlainText)
        {

        }
    }
}
