namespace BasicWebServer.Controllers
{
    using System;

    using BasicWebServer.HTTP;
    using BasicWebServer.Routing.Contracts;

    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable, 
            string url, 
            Func<TController, Response> controllerFunc)
                where TController : Controller
            => routingTable.MapGet(url, request => controllerFunc
            (CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string url,
            Func<TController, Response> controllerFunc)
                where TController : Controller
        {
            routingTable.MapPost(url, request => controllerFunc(CreateController<TController>(request)));

            return routingTable;
        }

        private static TController CreateController<TController>(Request request)
        {
            TController controller = (TController)Activator.CreateInstance(typeof(TController), new[] { request });

            return controller;
        }
    }
}
