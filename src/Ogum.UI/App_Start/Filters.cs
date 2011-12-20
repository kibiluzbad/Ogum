using System.Web.Mvc;

namespace Ogum.UI.App_Start
{
    public static class Filters
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}