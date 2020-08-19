namespace firstDemo.Common {
    public class PagedResponse {
        public int Size { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public string OrderByPropertyName { get; set; }
        public int SortDirection { get; set; }
    }
}