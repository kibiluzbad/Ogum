using System;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;
using Xango.Data;

namespace Ogum.UI.Infra.Automapper.Profiles
{
    public class TaskViewModelToTaskProfile : Profile
    {
      private readonly IRepository<Task> _repository;

      public TaskViewModelToTaskProfile()
      {
        _repository = ServiceLocator.Current.GetInstance<IRepository<Task>>();
      }

      protected override void Configure()
      {
        CreateMap<TaskViewModel, Task>()
          .ConstructUsing(c => _repository
                                 .FirstOrDefault(d => d.Id == c.Id))
          .ForMember(c => c.CreatedAt, c => c.Ignore())
          .ForMember(c => c.CreatedBy, c => c.Ignore())
          .ForMember(c => c.ChangedAt, c => c.MapFrom(d => DateTime.Now))
          .ForMember(c => c.ChangedBy, c => c.MapFrom(d => HttpContext.Current.Request.LogonUserIdentity.Name));
      }
    }
}