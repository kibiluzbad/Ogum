using Xango.Data;

namespace Ogum.UI.Domain
{
    public class Task : StampedEntity
    {
        public virtual string Name { get; set; }
        public virtual string Tag { get; set; }
    }
}