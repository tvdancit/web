using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace tdtt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Chi Tiet",
            url: "de-tai/{id}",
            defaults: new { controller = "Topic", action = "Details", id = UrlParameter.Optional }
          );
           
            routes.MapRoute(
            name: "Bang diem",
            url: "bang-diem",
            defaults: new { controller = "Home", action = "DataPoint", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "Detail",
             url: "thong-bao/{MetaTitle}-{id}",
             defaults: new { controller = "Home", action = "DetailNo", id = UrlParameter.Optional }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
