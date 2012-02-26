using System.Web.Mvc;
using SharpBrake.Mvc3;
using WebActivator;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.AirbrakeActivator), "Start")]
namespace $rootnamespace$.App_Start
{
    public static class AirbrakeActivator
    {
        public static void Start()
        {
            GlobalFilters.Filters.Add(new AirbrakeNoticeFilter());
        }
    }
}