using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace GT.IntegrationTests
{
    public static class ApiControllerExtensions
    {
        public static void ConfigureForTesting(this ControllerBase controller, HttpMethod method, string uri, string routeName = null, IHttpRoute route = null)
        {
            var request = new HttpRequestMessage(method, uri);
            ConfigureForTesting(controller, request, routeName, route);
        }

        public static void ConfigureForTesting(this ControllerBase controller, HttpRequestMessage request, string routeName = null, IHttpRoute route = null)
        {
            //var config = new HttpConfiguration();
            //controller.Configuration = config;
            //if (routeName != null && route != null)
            //{
            //    config.Routes.Add(routeName, route);
            //}
            //else
            //{
            //    route = config.Routes.MapHttpRoute("DefaultApi", "api/v{version}/{controller}/{id}", new { id = RouteParameter.Optional });
            //}

            //var controllerTypeName = controller.GetType().Name;
            //var controllerName = controllerTypeName.Substring(0, controllerTypeName.IndexOf("Controller", System.StringComparison.Ordinal)).ToLower();
            //var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", controllerName } });

            //controller.ControllerContext = new HttpControllerContext(config, routeData, request)
            //{
            //    ControllerDescriptor = new HttpControllerDescriptor(config, controllerName, controller.GetType())
            //};
            //controller.Request = request;
            //controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            //controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
    }
}
