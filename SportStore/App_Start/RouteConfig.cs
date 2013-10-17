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
                            "", // Only matches the empty URL (i.e. /)
                            new
                                {
                                    controller = "Product",
                                    action = "List",
                                    category = (string) null,
                                    pageNumber = 1
                                }
                );

            routes.MapRoute(null,
                            "Page{pageNumber}", // Matches /Page2, /Page123, but not /PageXYZ
                            new {controller = "Product", action = "List", category = (string) null},
                            new { pageNumber = @"\d+" } // Constraints: page must be numerical
                );

            routes.MapRoute(null,
                            "{category}", // Matches /Football or /AnythingWithNoSlash
                            new {controller = "Product", action = "List", pageNumber = 1}
                );

            routes.MapRoute(null,
                            "{category}/Page{pageNumber}", // Matches /Football/Page567
                            new {controller = "Product", action = "List"}, // Defaults
                            new { pageNumber = @"\d+" } // Constraints: page must be numerical
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}