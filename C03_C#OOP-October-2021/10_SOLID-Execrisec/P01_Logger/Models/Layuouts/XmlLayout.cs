namespace P01_Logger.Models.Layuouts
{
    using System.Text;

    using P01_Logger.Models.Contracts;

    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine("<log>")
                    .AppendLine("\t<date>{0}</date>")
                    .AppendLine("\t<level>{1}</level>")
                    .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString();
        }
    }
}
