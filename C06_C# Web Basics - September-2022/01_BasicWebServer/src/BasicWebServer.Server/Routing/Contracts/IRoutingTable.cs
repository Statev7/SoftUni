namespace BasicWebServer.Routing.Contracts
{
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HTTPMethod method, Response response);

        IRoutingTable MapGet(string url, Response response);

        IRoutingTable MapPost(string url, Response response);
    }
}
