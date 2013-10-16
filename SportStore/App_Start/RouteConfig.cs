using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,
                            "",
                            new { controller = "Product", action = "List", pageNumber = 1 });

            routes.MapRoute(null,
                            "Page{pageNumber}",
                            new {controller = "Product", action = "List"},
                            new { pageNumber = @"\d+" });
        }
    }
}