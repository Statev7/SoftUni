namespace BasicWebServer.Responses.ContentResponses
{
    using System;

    using BasicWebServer.HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content, Action<Request, Response> preRenderAction = null)
            :base(content, ContentType.HtmlText, preRenderAction)
        {

        }
    }
}
