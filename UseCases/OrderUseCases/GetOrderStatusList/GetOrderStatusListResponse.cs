using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.UseCases.OrderStatusUseCases.GetOrderStatusList
{
    public class GetOrderStatusListResponse: PagedResponse
    {
         public List<GetOrderStatusBase> Items { get; set; }
    }
}