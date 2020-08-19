using firstDemo.Common.Abstractions;

namespace firstDemo.Common
{
    public abstract class IntBaseEntity : IBaseEntity<int>
    {
        public virtual int Id { get; set; }
    }
}