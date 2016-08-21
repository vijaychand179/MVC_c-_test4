using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportScotland
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Impact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Impact", action = "GetAllImpacts", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddImpact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Impact", action = "AddImpact", id = UrlParameter.Optional }
            );
        }
    }
}