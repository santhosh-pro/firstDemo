using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common {
    public class PagingRepository<TEntity, TId> : CommonEntityRepository<TEntity, TId>, IPagingRepository<TEntity, TId>
        where TEntity : class, IBaseEntity<TId>, new () where TId : IEquatable<TId> {
            private readonly DbContext _dbContext;

            private const string IdPropertyName = "Id";
            private readonly IMapper _mapper;

            public PagingRepository (DbContext dbContext, IMapper mapper) : base (dbContext) {
                this._dbContext = dbContext;
                _mapper = mapper;
            }

            public virtual PagedModel<U, TId> GetPaged<U> (int page, int size,
                SortDirection sortDirection = SortDirection.Ascending) {
                var totalCount = this.Count ();

                var entities = this.CreateQuery ()

                    .ApplyOrder<TEntity, TId> (PagingRepository<TEntity, TId>.IdPropertyName,
                        GetOrderMethodName (sortDirection))
                    .OrderBy (entity => entity.Id)

                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArray ();

                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public virtual async Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size,
                SortDirection sortDirection = SortDirection.Ascending) {
                var totalCount = await this.CountAsync ();

                var entities = await this.CreateQuery ()
                    .ApplyOrder<TEntity, TId> (PagingRepository<TEntity, TId>.IdPropertyName,
                        GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArrayAsync ();

                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public virtual PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection = SortDirection.Ascending) {
                var totalCount = this.Count ();

                var entities = this.CreateQuery ()
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArray ();

                return new PagedModel<U, TId> (entities, page, size, totalCount, orderByPropertyName, sortDirection);
            }

            public async Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection = SortDirection.Ascending) {
                var totalCount = await this.CountAsync ();

                var entities = await this.CreateQuery ()
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToListAsync ();

                return new PagedModel<U, TId> (entities, page, size, totalCount, orderByPropertyName, sortDirection);
            }

            public PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection = SortDirection.Ascending, params Expression<Func<TEntity, object>>[] includes) {
                var totalCount = this.Count ();

                var entities = this.BuildIncludes (includes)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArray ();

                return new PagedModel<U, TId> (entities, page, size, totalCount, orderByPropertyName, sortDirection);
            }

            public async Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection = SortDirection.Ascending, params Expression<Func<TEntity, object>>[] includes) {
                var totalCount = await this.CountAsync ();

                var entities = await this.BuildIncludes (includes)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider, new { key = "340cafcd-90f9-4490-ae3c-6d4d595d2e29" })
                    .ToArrayAsync ();

                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection, Expression<Func<TEntity, bool>> predicate) {
                var totalCount = this.Count ();

                var entities = this.CreateQuery ()
                    .Where (predicate)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArray ();

                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public async Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection, Expression<Func<TEntity, bool>> predicate) {

                var entities = await this.BuildIncludes ()
                    .Where (predicate)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArrayAsync ();
                var totalCount = await this.CountAsync ();
                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection,
                Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[] includes) {
                var totalCount = this.Count ();

                var entities = this.BuildIncludes (includes)
                    .Where (predicate)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArray ();

                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public async Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
                SortDirection sortDirection,
                Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) {
                var totalCount = this.Count ();
                var entities = await this.BuildIncludes (includes)
                    .Where (predicate)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider)
                    .ToArrayAsync ();
                // var totalCount = entities.Count ();
                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            public async Task<PagedModel<U, TId>> GetPagedAsync<U> (object param, int page, int size, string orderByPropertyName,
                SortDirection sortDirection,
                Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) {
                var totalCount = this.Count ();
                var entities = await this.BuildIncludes (includes)
                    .Where (predicate)
                    .ApplyOrder<TEntity, TId> (orderByPropertyName, GetOrderMethodName (sortDirection))
                    .Skip ((page - 1) * size)
                    .Take (size)
                    .ProjectTo<U> (_mapper.ConfigurationProvider, param)
                    .ToArrayAsync ();
                // var totalCount = entities.Count ();
                return new PagedModel<U, TId> (entities, page, size, totalCount,
                    PagingRepository<TEntity, TId>.IdPropertyName, sortDirection);
            }

            private static string GetOrderMethodName (SortDirection sortDirection) {
                return !Enum.IsDefined (typeof (SortDirection), sortDirection) ?
                    QueryableExtensions.OrderByMethodName :
                    sortDirection == SortDirection.Ascending ?
                    QueryableExtensions.OrderByMethodName :
                    sortDirection == SortDirection.Descending ?
                    QueryableExtensions.OrderByDescendingMethodName :
                    sortDirection == SortDirection.ThenByAscending ?
                    QueryableExtensions.ThenOrderByMethodName :
                    QueryableExtensions.ThenOrderByDescendingMethodName;
            }
        }
}