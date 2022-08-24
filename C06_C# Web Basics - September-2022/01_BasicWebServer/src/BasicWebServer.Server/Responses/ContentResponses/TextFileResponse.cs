namespace BasicWebServer.Responses.ContentResponses
{
    using System.IO;

    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public class TextFileResponse : Response
    {
        public TextFileResponse(string fileName)
            :base(StatusCode.OK)
        {
            this.FileName = fileName;

            this.Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public string FileName { get; init; }

        public override string ToString()
        {
            if (File.Exists(this.FileName))
            {
                this.Body = File.ReadAllTextAsync(this.FileName).Result;

                long fileBytesCount = new FileInfo(this.FileName).Length;
                string BytesCountAsString = fileBytesCount.ToString();

                this.Headers.Add(Header.ContentLength, BytesCountAsString);
                this.Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{this.FileName}\"");
            }

            return base.ToString(); 
        }
    }
}
