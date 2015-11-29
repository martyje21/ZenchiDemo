using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace zenchi.oauth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Login",
              url: "login",
              defaults: new { controller = "Auth", action = "Login" }
           );

            routes.MapRoute(
               name: "Logout",
               url: "logout",
               defaults: new { controller = "Auth", action = "Logout" }
            );

            routes.MapRoute(
               name: "Register",
               url: "register",
               defaults: new { controller = "Auth", action = "Register" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auth", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
