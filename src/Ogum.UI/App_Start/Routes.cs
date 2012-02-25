using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Ogum.UI.App_Start
{
    public static class Routes
    {
      public static void RegisterRoutes(RouteCollection routes)
      {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.Root();
        routes.MapRoute("ClientRoute",
                        "tasks/{year}/{month}/{day}",
                        new { controller = "Home", action = "Index" },
                        new { httpMethod = new HttpMethodConstraint("GET") });
        routes.MapRoute("GetTasksByDate",
                        "api/tasks/{year}/{month}/{day}",
                        new {controller = "Tasks", action = "Index"},
                        new {httpMethod = new HttpMethodConstraint("GET")});
        routes.Resource("tasks", "api");
      }
    }

    public static class RouteExtensions
    {
      public static RouteCollection Resource(this RouteCollection routes,
          string controller,
          string @namespace = null)
      {
        routes.MapRoute(
            string.Format("New{0}", controller), // Route name
            GetRoutePath(controller, "Create", @namespace), // URL with parameters
            new { action = "Create", controller }, // Parameter defaults
            new { httpMethod = new HttpMethodConstraint("GET") }
            );

        routes.MapRoute(
            string.Format("Create{0}", controller), // Route name
            GetRoutePath(controller, @namespace: @namespace), // URL with parameters
            new { action = "Create", controller }, // Parameter defaults
            new { httpMethod = new HttpMethodConstraint("POST") }
            );

        routes.MapRoute(
          string.Format("Show{0}", controller), // Route name
          GetRoutePath(controller, "{id}", @namespace),
          new { action = "Details", controller }, // Parameter defaults
          new { httpMethod = new HttpMethodConstraint("GET") }
          );

        routes.MapRoute(
            string.Format("Update{0}", controller), // Route name
            GetRoutePath(controller, "{id}", @namespace),
            new { action = "Update", controller },
            new { httpMethod = new HttpMethodConstraint("PUT") }
            );

        routes.MapRoute(
            string.Format("Edit{0}", controller), // Route name
            GetRoutePath(controller, "{id}/Edit", @namespace),
            new { action = "Edit", controller },
            new { httpMethod = new HttpMethodConstraint("GET") }
            );

        routes.MapRoute(
            string.Format("List{0}", controller), // Route name
            GetRoutePath(controller, @namespace: @namespace),
            new { action = "Index", controller }, // Parameter defaults
            new { httpMethod = new HttpMethodConstraint("GET") }
            );

        routes.MapRoute(
            string.Format("Delete{0}", controller), // Route name
            GetRoutePath(controller, "{id}", @namespace),
            new { action = "Delete", controller }, // Parameter defaults
            new { httpMethod = new HttpMethodConstraint("DELETE") }
            );

        return routes;
      }

      private static string GetRoutePath(string controller, string action = null, string @namespace = null)
      {
        var start = string.IsNullOrWhiteSpace(@namespace)
                        ? controller
                        : string.Format("{0}/{1}", @namespace, controller);

        return !string.IsNullOrWhiteSpace(action)
                   ? string.Format("{0}/{1}", start, action)
                   : start;
      }


      public static RouteCollection Root(this RouteCollection routes, string controller = "Home", string action = "Index")
      {
        routes.MapRoute(
            "Root", // Route name
            "", // URL with parameters
            new { controller = controller, action = action }
            );
        return routes;
      }

    }
}