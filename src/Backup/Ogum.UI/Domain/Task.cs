using System;

namespace Ogum.UI.Domain
{
  public class Task
  {
    public long Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Tag { get; set; }
    public virtual TaskStatus Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ChangedAt { get; set; }
    public string ChangedBy { get; set; }

    public Task()
    {
      CreatedAt = DateTime.Now;
    }
  }
}