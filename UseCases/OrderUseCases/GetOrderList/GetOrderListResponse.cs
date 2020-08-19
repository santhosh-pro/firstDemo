using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.UseCases.OrderUseCases.GetOrderList
{
    public class GetOrderListResponse: PagedResponse
    {
         public List<GetOrderBase> Items { get; set; }
    }
}