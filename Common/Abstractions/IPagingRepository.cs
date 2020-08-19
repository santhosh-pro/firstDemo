using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace firstDemo.Common.Abstractions {
    public interface IPagingRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new () where TId : IEquatable<TId> {
        PagedModel<U, TId> GetPaged<U> (int page, int size, SortDirection sortDirection = SortDirection.Ascending);

        Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, SortDirection sortDirection = SortDirection.Ascending);
        PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection = SortDirection.Ascending);

        Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection = SortDirection.Ascending);

        PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection = SortDirection.Ascending, params Expression<Func<TEntity, object>>[] includes);

        Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection = SortDirection.Ascending, params Expression<Func<TEntity, object>>[] includes);

        PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection,
            Expression<Func<TEntity, bool>> predicate);

        Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection,
            Expression<Func<TEntity, bool>> predicate);

        PagedModel<U, TId> GetPaged<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<PagedModel<U, TId>> GetPagedAsync<U> (int page, int size, string orderByPropertyName,
            SortDirection sortDirection,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<PagedModel<U, TId>> GetPagedAsync<U> (object param, int page, int size, string orderByPropertyName,
            SortDirection sortDirection,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);
    }
}