
namespace firstDemo.Common
{
    public class PagingParams
    {
        private const int MaxPageSize = 50;
        private int pageSize = 10;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public SortDirection SortingDirection { get; set; }=SortDirection.Ascending;
        public string OrderByPropertyName { get; set; }="LastModifiedAt";
        public string SearchKey { get; set; }
    }
}