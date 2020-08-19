using AutoMapper;
using firstDemo.Common;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderStatusUseCases.GetOrderStatusList
{
    public class GetOrderStatusListMapper: Profile
    {
        public GetOrderStatusListMapper()
        {
            CreateMap<OrderStatus, GetOrderStatusBase> ();
             

            CreateMap<PagedModel<GetOrderStatusBase,int>, GetOrderStatusListResponse> ();
        }
    }
}