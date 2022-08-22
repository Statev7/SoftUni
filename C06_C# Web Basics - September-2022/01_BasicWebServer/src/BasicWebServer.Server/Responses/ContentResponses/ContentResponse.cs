namespace BasicWebServer.Responses.ContentResponses
{
    using BasicWebServer.Common;
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType)
            :base(StatusCode.OK)
        {
            Guard.AgaintsNull(content);
            Guard.AgaintsNull(contentType);

            this.Headers.Add("Content-Type", contentType);

            this.Body = content;
        }
    }
}
