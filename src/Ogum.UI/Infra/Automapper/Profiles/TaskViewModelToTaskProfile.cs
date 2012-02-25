using System;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;
using Raven.Client;

namespace Ogum.UI.Infra.Automapper.Profiles
{
    public class TaskViewModelToTaskProfile : Profile
    {
      private IDocumentSession _session;

      public TaskViewModelToTaskProfile()
      {
         _session = ServiceLocator.Current.GetInstance<IDocumentSession>();
      }

      protected override void Configure()
      {
        CreateMap<TaskViewModel, Task>().ConstructUsing(c=> _session.Load<Task>(c.Id))
          .ForMember(c => c.CreatedAt, c => c.Ignore())
          .ForMember(c => c.CreatedBy, c => c.Ignore())
          .ForMember(c => c.ChangedAt, c => c.MapFrom(d => DateTime.Now))
          .ForMember(c => c.ChangedBy, c => c.MapFrom(d => HttpContext.Current.Request.LogonUserIdentity.Name));
      }
    }
}