namespace BasicWebServer.Responses.ContentResponses
{
    using System;

    using BasicWebServer.HTTP;

    public class TextResponse : ContentResponse
    {
        public TextResponse(string content, Action<Request, Response> preRenderAction = null)
            :base(content, ContentType.PlainText, preRenderAction)
        {

        }
    }
}
