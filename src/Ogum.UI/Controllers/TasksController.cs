using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;
using Xango.Data;
using Xango.Data.NHibernate.Filters;
using Xango.Data.NHibernate.Queries;
using Xango.Data.Query;
using Xango.Mvc.Controller;

namespace Ogum.UI.Controllers
{
    public class TasksController : Controller
    {
        private readonly IRepository<Task> _repository;
        private readonly ISessionFactory _sessionFactory;

        public TasksController(IRepository<Task> repository, ISessionFactory sessionFactory)
        {
            _repository = repository;
            _sessionFactory = sessionFactory;
        }

        [HttpGet]
        [NeedsPersistence]
        public ActionResult Index()
        {
            var tasks = _repository.ToList();

            return Json(Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(tasks),
                        JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NeedsPersistence]
        public ActionResult Create(TaskViewModel viewModel)
        {
            var task = Mapper.Map<TaskViewModel, Task>(viewModel);
            _repository.Add(task);

            return Json(Mapper.Map<Task, TaskViewModel>(task));
        }

        [HttpPut]
        [NeedsPersistence]
        public ActionResult Update(long id, TaskViewModel viewModel)
        {
            var task = Mapper.Map<TaskViewModel, Task>(viewModel);
            _sessionFactory.GetCurrentSession().Update(task);

            return Json(Mapper.Map<Task, TaskViewModel>(task));
        }

        [HttpDelete]
        [NeedsPersistence]
        public ActionResult Delete(long id)
        {
            var query = _repository.CreateQuery<IGetEntityById<Task>>();
            query.Id = id;

            var task = query.Execute();

            _repository.Remove(task);

            return Json(Mapper.Map<Task, TaskViewModel>(task));
        }
    }
}
