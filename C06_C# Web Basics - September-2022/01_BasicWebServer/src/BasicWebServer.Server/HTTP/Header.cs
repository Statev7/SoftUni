namespace BasicWebServer.HTTP
{
    using BasicWebServer.Common;

    public class Header
    {
        public Header(string name, string value)
        {
            Guard.AgaintsNull(name, nameof(name));
            Guard.AgaintsNull(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; init; }

        public string Value { get; init; }
    }
}
