namespace BasicWebServer.Responses.ContentResponses
{
    using System.Text;

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

        public override string ToString()
        {
            if (this.Body != null)
            {
                string contentLengthAsString = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLength, contentLengthAsString);
            }

            return base.ToString();
        }
    }
}
