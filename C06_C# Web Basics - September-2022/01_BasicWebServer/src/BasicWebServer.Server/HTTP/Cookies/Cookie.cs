namespace BasicWebServer.HTTP.Cookies
{
    using BasicWebServer.Common;

    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Guard.AgaintsNull(name, nameof(name));
            Guard.AgaintsNull(value, nameof(value));

            this.Name = name;
            this.Value = value; 
        }

        public string Name { get; init; }

        public string Value { get; init; }

        public override string ToString()
            => $"{this.Name}={this.Value}";
    }
}
