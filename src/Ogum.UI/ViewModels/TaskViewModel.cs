using System;
using Xango.Mvc.ViewModel;

namespace Ogum.UI.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public DateTime CreateAt { get; set; }
    }
}