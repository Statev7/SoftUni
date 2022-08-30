namespace BasicWebServer.Responses.ContentResponses
{
    using System.IO;
    using System.Linq;

    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName, object model = null) 
            : base("", ContentType.HtmlText)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            string viewPath = Path.GetFullPath($"./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");
            string viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.Body = viewContent;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(x => new
                {
                    Name = x.Name,
                    Value = x.GetValue(model)
                });

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent
                    .Replace($"{openingBrackets}{entry.Name}{closingBrackets}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
