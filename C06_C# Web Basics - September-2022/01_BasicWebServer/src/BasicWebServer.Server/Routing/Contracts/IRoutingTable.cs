namespace BasicWebServer.Routing.Contracts
{
    using System;

    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;

    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HTTPMethod method, Func<Request, Response> responseFunction);

        IRoutingTable MapGet(string url, Func<Request, Response> responseFunction);

        IRoutingTable MapPost(string url, Func<Request, Response> responseFunction);
    }
}
