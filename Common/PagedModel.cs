using System;
using System.Collections.Generic;

namespace firstDemo.Common
{
    public class PagedModel<TEntity, TId> 
    {
        public int Size { get; }

        public int Page { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public string OrderByPropertyName { get; }

        public SortDirection SortDirection { get; }

        public IEnumerable<TEntity> Items { get; }

        public PagedModel(IEnumerable<TEntity> items,
            int page,
            int size,
            int totalCount, 
            string orderByPropertyName, 
            SortDirection sortDirection)
        {
            this.TotalPages = size == 0
                ? 0
                : (int)Math.Ceiling((decimal)totalCount / size);

            this.Items = items;
            this.Size = size;
            this.Page = page;
            this.TotalCount = totalCount;
            this.OrderByPropertyName = orderByPropertyName;
            this.SortDirection = sortDirection;
        }
    }
}