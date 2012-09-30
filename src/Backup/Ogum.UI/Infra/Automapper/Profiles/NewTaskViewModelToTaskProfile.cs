using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AutoMapper;
using Ogum.UI.Domain;
using Ogum.UI.ViewModels;

namespace Ogum.UI.Infra.Automapper.Profiles
{
  public class NewTaskViewModelToTaskProfile : Profile
  {
    protected override void Configure()
    {
      CreateMap<NewTaskViewModel, Task>()
        .ForMember(c => c.Name, c => c.MapFrom(d => GetName(d)))
        .ForMember(c => c.CreatedAt, c => c.MapFrom(d => DateTime.Now))
        .ForMember(c => c.CreatedBy, c => c.MapFrom(d => HttpContext.Current.Request.LogonUserIdentity.Name))
        .ForMember(c => c.Tag, c => c.MapFrom(d => string.Join(" ", GetTags(d).ToList())));
    }

    private static string GetName(NewTaskViewModel viewModel)
    {
      return viewModel.Name.Substring(0, viewModel.Name.IndexOf("#") - 1);
    }

    private static IEnumerable<string> GetTags(NewTaskViewModel viewModel)
    {
      return from Match match
               in Regex.Matches(viewModel.Name, @"\#(\w+)")
             select match.Groups[1].Value;
    }
  }
}