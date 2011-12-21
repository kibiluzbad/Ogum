using AutoMapper;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;

namespace Ogum.UI.Infra.Automapper.Profiles
{
    public class TaskToTaskViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Task, TaskViewModel>();
        }
    }
}