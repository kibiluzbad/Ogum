using System;
using System.Web;
using AutoMapper;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;

namespace Ogum.UI.Infra.Automapper.Profiles
{
    public class TaskViewModelToTaskProfile : Profile
    {
        protected override void Configure()
        {
          //TODO: Fix CreatedAt bug.
          CreateMap<TaskViewModel, Task>()
            .ForMember(c=>c.ChangedAt, c=>c.MapFrom(d=> DateTime.Now))
            .ForMember(c=>c.ChangedBy, c=>c.MapFrom(d=> HttpContext.Current.Request.LogonUserIdentity.Name));
        }
    }
}