using AutoMapper;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;

namespace Ogum.UI.Infra.Automapper.Profiles
{
    public class TaskViewModelToTaskProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<TaskViewModel, Task>()
                .ForMember(c=>c.CreatedAt, c=> c.Ignore());
        }
    }
}