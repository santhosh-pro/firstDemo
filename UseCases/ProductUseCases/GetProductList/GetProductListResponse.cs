using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.UseCases.ProductUseCases.GetProductList
{
    public class GetProductListResponse: PagedResponse
    {
         public List<GetProductBase> Items { get; set; }
    }
}