using AutoMapper;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.OrderUseCases.GetOrder
{
    public class GetOrderMapper: Profile
    {
        public GetOrderMapper()
        {
            CreateMap<Order,GetOrderResponse> ();
        }
    }
}