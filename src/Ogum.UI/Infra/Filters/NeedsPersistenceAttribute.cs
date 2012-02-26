using System;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Raven.Client;

namespace Ogum.UI.Infra.Filters
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
  public class NeedsPersistenceAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(
      ActionExecutingContext filterContext)
    {
      
    }

    public override void OnActionExecuted(
      ActionExecutedContext filterContext)
    {
      var session = ServiceLocator.Current.GetInstance<IDocumentSession>();

      using (session)
      {
        if (null != session && null == filterContext.Exception)
        {
          session.SaveChanges();
        }
      }
    }
  }
}