using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ogum.UI.Infra.Extensions;


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
}