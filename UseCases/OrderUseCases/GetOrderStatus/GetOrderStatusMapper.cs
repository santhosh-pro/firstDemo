using AutoMapper;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.OrderStatusUseCases.GetOrderStatus
{
    public class GetOrderStatusMapper: Profile
    {
        public GetOrderStatusMapper()
        {
            CreateMap<OrderStatus,GetOrderStatusResponse> ();
        }
    }
}