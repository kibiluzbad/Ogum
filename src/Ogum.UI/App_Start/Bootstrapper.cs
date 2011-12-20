using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogum.UI.App_Start.Bootstrapper), "Start", Order = 0)]
[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogum.UI.App_Start.Bootstrapper), "Stop", Order = 0)]
namespace Ogum.UI.App_Start
{
    
    public static class Bootstrapper
    {
        public static void Start()
        {
            Xango.Data.NHibernate.Configuration.NHFluentConfiguration.Init();

            AreaRegistration.RegisterAllAreas();

            Routes.RegisterRoutes(RouteTable.Routes);

            Filters.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public static void Stop()
        { }
    }
}