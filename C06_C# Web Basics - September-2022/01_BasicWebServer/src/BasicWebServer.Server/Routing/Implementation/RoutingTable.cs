namespace BasicWebServer.Routing.Implementation
{
    using System;
    using System.Collections.Generic;

    using BasicWebServer.Common;
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Enums;
    using BasicWebServer.Responses.ActionResponses;
    using BasicWebServer.Routing.Contracts;

    public class RoutingTable : IRoutingTable
    {
        private readonly IDictionary<HTTPMethod, Dictionary<string, Response>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<HTTPMethod, Dictionary<string, Response>>()
            {
                [HTTPMethod.Get] = new(),
                [HTTPMethod.Post] = new(),
                [HTTPMethod.Put] = new(),
                [HTTPMethod.Delete] = new()
            };
        }

        public IRoutingTable Map(string url, HTTPMethod method, Response response)
        {
            return method switch
            {
                HTTPMethod.Get => this.MapGet(url, response),
                HTTPMethod.Post => this.MapPost(url, response),
                _ => throw new InvalidOperationException($"Method '{method}' is not supported."),
            };
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgaintsNull(url, nameof(url));
            Guard.AgaintsNull(response, nameof(response));

            this.routes[HTTPMethod.Get][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgaintsNull(url, nameof(url));
            Guard.AgaintsNull(response, nameof(response));

            this.routes[HTTPMethod.Post][url] = response;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            HTTPMethod requestMethod = request.HTTPMethod;
            string requestUrl = request.Url;

            if(!this.routes.ContainsKey(requestMethod) 
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
