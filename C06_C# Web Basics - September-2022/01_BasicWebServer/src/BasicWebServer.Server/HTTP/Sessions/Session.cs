namespace BasicWebServer.HTTP.Sessions
{
    using System.Collections.Generic;

    using BasicWebServer.Common;

    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";

        private readonly IDictionary<string, string> date;

        private Session()
        {
            this.date = new Dictionary<string, string>();
        }

        public Session(string id)
            :this()
        {
            Guard.AgaintsNull(id, nameof(id));

            this.Id = id;
        }

        public string Id { get; set; }

        public string this[string key]
        {
            get => this.date[key];
            set => this.date[key] = value;
        }

        public bool Contains(string key)
            => this.date.ContainsKey(key);
    }
}
