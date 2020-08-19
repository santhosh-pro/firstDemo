using System;

namespace firstDemo.Common.Abstractions
{
    public interface IBaseEntity<out TId> where TId : IEquatable<TId>
    {
        TId Id { get; }
        
    }
}