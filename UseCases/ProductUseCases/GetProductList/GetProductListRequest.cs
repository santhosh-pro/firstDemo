using firstDemo.Common;

namespace firstDemo.UseCases.ProductUseCases.GetProductList
{
    public class GetProductListRequest:PagingParams
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string CategoryId { get; set; }
    }
}