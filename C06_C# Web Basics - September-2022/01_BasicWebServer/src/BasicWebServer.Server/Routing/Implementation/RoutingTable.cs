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
        private readonly IDictionary<HTTPMethod, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<HTTPMethod, Dictionary<string, Func<Request, Response>>>()
            {
                [HTTPMethod.Get] = new(),
                [HTTPMethod.Post] = new(),
                [HTTPMethod.Put] = new(),
                [HTTPMethod.Delete] = new()
            };
        }

        public IRoutingTable Map(string url, HTTPMethod method, Func<Request, Response> responseFunction)
        {
            Guard.AgaintsNull(url, nameof(url));
            Guard.AgaintsNull(responseFunction, nameof(responseFunction));

            this.routes[method][url] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string url, Func<Request, Response> responseFunction)
            => this.Map(url, HTTPMethod.Get, responseFunction);

        public IRoutingTable MapPost(string url, Func<Request, Response> responseFunction)
            => this.Map(url, HTTPMethod.Post, responseFunction);

        public Response MatchRequest(Request request)
        {
            HTTPMethod requestMethod = request.HTTPMethod;
            string requestUrl = request.Url;

            if(!this.routes.ContainsKey(requestMethod) 
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl](request);
        }
    }
}
