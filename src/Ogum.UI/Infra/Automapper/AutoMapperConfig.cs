using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Ogum.UI.Infra.Automapper.Profiles;

namespace Ogum.UI.Infra.Automapper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.AddProfile<TaskToTaskViewModelProfile>();            
            Mapper.AddProfile<TaskViewModelToTaskProfile>();            
        }
    }
}