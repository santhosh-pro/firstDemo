using firstDemo.Common.Abstractions;

namespace firstDemo.Common
{
    public abstract class StringBaseEntity : IBaseEntity<string>
    {
        public virtual string Id { get; set; }
    }
}