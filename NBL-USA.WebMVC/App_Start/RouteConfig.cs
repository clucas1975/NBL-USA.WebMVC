using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NBL_USA.WebMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //URL=is what builds out the Url we see on the webpage.
                                                   //{controller}=is the particular controller we are using.
                                                   //{action}=is the ActionResult we are calling on (Create, Details, Edit, or Delete).
                                                   //{id}=is an optional parameter that will only be used when we are working with a specific LeagueStaff.
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
