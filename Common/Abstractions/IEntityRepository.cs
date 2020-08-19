using System;

namespace firstDemo.Common.Abstractions
{
    public interface IEntityRepository<TEntity, TId> : 
        IReadEntityRepository<TEntity, TId>,
        IWriteEntityRepository<TEntity, TId>,
        ICommonEntityRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new() where TId : IEquatable<TId>
    {
        
    }
}