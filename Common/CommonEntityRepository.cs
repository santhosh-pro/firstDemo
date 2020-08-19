using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common
{
    public abstract class CommonEntityRepository<TEntity, TId> : IDisposable, ICommonEntityRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new() where TId : IEquatable<TId>
    {
        private readonly DbContext _dbContext;

        protected CommonEntityRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual IQueryable<TEntity> GetQueryAble(bool noTracking = false)
        {
            return noTracking
                ? this.CreateQuery().AsNoTracking()
                : this.CreateQuery();
        }

        public virtual int Count()
        {
            return this.CreateQuery()
                .Select(entity => entity.Id)
                .Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await this.CreateQuery()
                .Select(entity => entity.Id)
                .CountAsync()
                .ConfigureAwait(false);
        }
        
        public void Dispose()
        {
            this._dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        
        protected IQueryable<TEntity> BuildIncludes(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.CreateQuery();

            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        protected IQueryable<TEntity> CreateQuery()
        {
            return this._dbContext.Set<TEntity>().AsQueryable();
        }
    }
}