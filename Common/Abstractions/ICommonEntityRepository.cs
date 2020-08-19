using System;
using System.Linq;
using System.Threading.Tasks;

namespace firstDemo.Common.Abstractions {
    public interface ICommonEntityRepository<out TEntity, in TId> where TEntity : class, IBaseEntity<TId>, new ()
    where TId : IEquatable<TId> {
        IQueryable<TEntity> GetQueryAble (bool noTracking = false);

        int Count ();

        Task<int> CountAsync ();

    }
}