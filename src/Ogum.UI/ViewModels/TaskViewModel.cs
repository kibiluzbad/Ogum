using System;
using Ogum.UI.Domain;
using Xango.Mvc.ViewModel;

namespace Ogum.UI.ViewModels
{
  public class TaskViewModel : ViewModelBase
  {
    public string Name { get; set; }
    public string Tag { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
  }

  public class NewTaskViewModel
  {
    public string Name { get; set; }
  }
}