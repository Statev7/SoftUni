namespace BasicWebServer.HTTP
{
    using System.Collections;
    using System.Collections.Generic;

    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly IDictionary<string, Header> headers;

        public HeaderCollection() 
            => this.headers = new Dictionary<string, Header>();

        public int Count => this.headers.Count;

        public void Add(string name, string value)
            => this.headers.Add(name, new Header(name, value));

        public IEnumerator<Header> GetEnumerator() => this.headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
