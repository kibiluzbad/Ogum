using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ogum.UI.Infra.Automapper;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogum.UI.App_Start.Bootstrapper), "Start", Order = 0)]
[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogum.UI.App_Start.Bootstrapper), "Stop", Order = 0)]
namespace Ogum.UI.App_Start
{
    
    public static class Bootstrapper
    {
        public static void Start()
        {
            Xango.Data.NHibernate.Configuration.NHFluentConfiguration.Init();

            Routes.RegisterRoutes(RouteTable.Routes);

            Filters.RegisterGlobalFilters(GlobalFilters.Filters);

            AutoMapperConfig.Configure();
        }

        public static void Stop()
        { }
    }
}