using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common {
    public class EntityRepository<TEntity, TId> : CommonEntityRepository<TEntity, TId>, IEntityRepository<TEntity, TId>
        where TEntity : class, IBaseEntity<TId>, new () where TId : IEquatable<TId> {
            private readonly DbContext _dbContext;
            public EntityRepository (DbContext dbContext) : base (dbContext) {
                this._dbContext = dbContext;
            }

            public virtual IEnumerable<TEntity> GetAll () {
                return this
                    .CreateQuery ()
                    .ToArray ();
            }

            public virtual IEnumerable<TType> GetAll<TType> (Expression<Func<TEntity, TType>> projectToFunc) where TType : class {
                return this.CreateQuery ()
                    .Select (projectToFunc)
                    .ToArray ();
            }

            public virtual async Task<IEnumerable<TEntity>> GetAllAsync () {
                return await this.CreateQuery ()
                    .ToArrayAsync ()
                    .ConfigureAwait (false);
            }

            public virtual async Task<IEnumerable<TType>> GetAllAsync<TType> (Expression<Func<TEntity, TType>> projectToFunc)
            where TType : class {
                return await this.GetQueryAble ()
                    .Select (projectToFunc)
                    .ToArrayAsync ()
                    .ConfigureAwait (false);
            }

            public virtual IEnumerable<TEntity> GetAll (params Expression<Func<TEntity, object>>[] includes) {
                return this.BuildIncludes (includes).ToArray ();
            }

            public virtual IEnumerable<TType> GetAll<TType> (Expression<Func<TEntity, TType>> projectToFunc,
                params Expression<Func<TEntity, object>>[] includes) where TType : class {
                return this.BuildIncludes (includes)
                    .Select (projectToFunc)
                    .ToArray ();
            }

            public virtual async Task<IEnumerable<TEntity>> GetAllAsync (params Expression<Func<TEntity, object>>[] includes) {
                return await this.BuildIncludes (includes).ToArrayAsync ();
            }

            public virtual async Task<IEnumerable<TType>> GetAllAsync<TType> (Expression<Func<TEntity, TType>> projectToFunc,
                params Expression<Func<TEntity, object>>[] includes) where TType : class {
                return await this.BuildIncludes (includes)
                    .Select (projectToFunc)
                    .ToArrayAsync ();
            }

            public virtual IEnumerable<TEntity> FindAll (Expression<Func<TEntity, bool>> predicate) {
                return this.CreateQuery ()
                    .Where (predicate)
                    .ToArray ();
            }

            public virtual IEnumerable<TType> FindAll<TType> (Expression<Func<TEntity, TType>> projectToFunc,
                Expression<Func<TEntity, bool>> predicate) where TType : class {
                return this.CreateQuery ()
                    .Where (predicate)
                    .Select (projectToFunc)
                    .ToArray ();
            }

            public virtual async Task<IEnumerable<TEntity>> FindAllAsync (Expression<Func<TEntity, bool>> predicate) {
                return await this.CreateQuery ()
                    .Where (predicate)
                    .ToArrayAsync ()
                    .ConfigureAwait (false);
            }

            public virtual async Task<IEnumerable<TType>> FindAllAsync<TType> (Expression<Func<TEntity, TType>> projectToFunc, Expression<Func<TEntity, bool>> predicate) where TType : class {
                return await this.CreateQuery ()
                    .Where (predicate)
                    .Select (projectToFunc)
                    .ToArrayAsync ()
                    .ConfigureAwait (false);
            }

            public virtual IEnumerable<TEntity> FindAll (Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) {
                return this.BuildIncludes (includes)
                    .Where (predicate)
                    .ToArray ();
            }

            public virtual IEnumerable<TType> FindAll<TType> (Expression<Func<TEntity, TType>> projectToFunc, Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) where TType : class {
                return this.BuildIncludes (includes)
                    .Where (predicate)
                    .Select (projectToFunc)
                    .ToArray ();
            }

            public virtual async Task<IEnumerable<TEntity>> FindAllAsync (Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) {
                return await this.BuildIncludes (includes)
                    .Where (predicate)
                    .ToArrayAsync ()
                    .ConfigureAwait (false);
            }

            public virtual async Task<IEnumerable<TType>> FindAllAsync<TType> (Expression<Func<TEntity, TType>> projectToFunc, Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) where TType : class {
                return await this.BuildIncludes (includes)
                    .Where (predicate)
                    .Select (projectToFunc)
                    .ToArrayAsync ()
                    .ConfigureAwait (false);
            }

            public virtual TEntity Find (TId key) {
                return this.CreateQuery ()
                    .FirstOrDefault (entity => entity.Id.Equals (key));
            }

            public virtual async Task<TEntity> FindAsync (TId key) {
                return await this.CreateQuery ()
                    .FirstOrDefaultAsync (entity => entity.Id.Equals (key))
                    .ConfigureAwait (false);
            }

            public virtual TEntity Find (TId key, params Expression<Func<TEntity, object>>[] includes) {
                return this.BuildIncludes (includes)
                    .FirstOrDefault (entity => entity.Id.Equals (key));
            }

            public virtual async Task<TEntity> FindAsync (TId key, params Expression<Func<TEntity, object>>[] includes) {
                return await this.BuildIncludes (includes)
                    .FirstOrDefaultAsync (entity => entity.Id.Equals (key))
                    .ConfigureAwait (false);
            }

            public virtual TEntity Find (Expression<Func<TEntity, bool>> predicate) {
                return this.CreateQuery ().FirstOrDefault (predicate);
            }

            public virtual async Task<TEntity> FindAsync (Expression<Func<TEntity, bool>> predicate) {
                return await this.CreateQuery ()
                    .FirstOrDefaultAsync (predicate)
                    .ConfigureAwait (false);
            }

            public virtual TEntity Find (Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) {
                return this.BuildIncludes (includes)
                    .FirstOrDefault (predicate);
            }

            public virtual async Task<TEntity> FindAsync (Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) {
                return await this.BuildIncludes (includes)
                    .FirstOrDefaultAsync (predicate)
                    .ConfigureAwait (false);
            }

            public bool HasMatching (Expression<Func<TEntity, bool>> predicate) {
                return this.GetQueryAble (true)
                    .Any (predicate);
            }

            public async Task<bool> HasMatchingAsync (Expression<Func<TEntity, bool>> predicate) {
                return await this.GetQueryAble (true)
                    .AnyAsync (predicate);
            }

            public virtual void Add (TEntity entity) {
                this._dbContext.Set<TEntity> ().Add (entity);
            }

            public virtual async Task AddAsync (TEntity entity) {
                await this._dbContext.Set<TEntity> ().AddAsync (entity);
            }

            public void AddMany (IEnumerable<TEntity> entities) {
                this._dbContext.Set<TEntity> ().AddRange (entities);
            }

            public async Task AddManyAsync (IEnumerable<TEntity> entities) {
                await this._dbContext.Set<TEntity> ().AddRangeAsync (entities);
            }

            public virtual void Edit (TEntity entity) {
                var entry = this._dbContext.Entry (entity);

                entry.State = EntityState.Modified;
            }
            public virtual void UpdateMany (IEnumerable<TEntity> entities) {
                _dbContext.Set<TEntity> ().UpdateRange (entities);
            }

            public virtual void Delete (TEntity entity) {
                var entry = this._dbContext.Entry (entity);

                entry.State = EntityState.Deleted;
            }
            public virtual bool EnsureChanges () {
                var modifiedCount = this._dbContext.SaveChanges ();

                return modifiedCount > 0;
            }

            public virtual async Task<bool> EnsureChangesAsync () {
                var modifiedCount = await this._dbContext.SaveChangesAsync ();

                return modifiedCount > 0;
            }
        }
}