using System;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common
{
    public abstract class GuidBaseEntity : IBaseEntity<Guid>
    {
        public virtual Guid Id { get; set; }
    }
}