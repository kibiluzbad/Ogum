using System.Web.Mvc;
using SharpBrake.Mvc3;
using WebActivator;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogum.UI.App_Start.AirbrakeActivator), "Start")]
namespace Ogum.UI.App_Start
{
    public static class AirbrakeActivator
    {
        public static void Start()
        {
            GlobalFilters.Filters.Add(new AirbrakeNoticeFilter());
        }
    }
}