using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;
using Raven.Client;

namespace Ogum.UI.Controllers
{
  public class TasksController : Controller
  {
    private readonly IDocumentSession _session;

    public TasksController(IDocumentSession session)
    {
      _session = session;
    }

    [HttpGet]
    [NeedsPersistence]
    public ActionResult Index(int year, int month, int day)
    {
      var date = new DateTime(year, month, day);

      var tasks = _session.Query<Task>().Where(c => c.CreatedAt.Date == date);

      return Json(Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(tasks),
                  JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    [NeedsPersistence]
    public ActionResult Create(NewTaskViewModel viewModel)
    {
      var task = Mapper.Map<NewTaskViewModel, Task>(viewModel);
      _session.Store(task);

      return Json(Mapper.Map<Task, TaskViewModel>(task));
    }

    [HttpPut]
    [NeedsPersistence]
    public ActionResult Update(long id, TaskViewModel viewModel)
    {
      var task = Mapper.Map<TaskViewModel, Task>(viewModel);
      
      return Json(Mapper.Map<Task, TaskViewModel>(task));
    }

    [HttpDelete]
    [NeedsPersistence]
    public ActionResult Delete(long id)
    {
      var task = _session.Load<Task>(id);

      _session.Delete(task);

      return Json(Mapper.Map<Task, TaskViewModel>(task));
    }
  }

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
