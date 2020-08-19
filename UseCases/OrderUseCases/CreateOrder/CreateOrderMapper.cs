using AutoMapper;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderUseCases.CreateOrder
{
    public class CreateOrderMapper : Profile
    {
        public CreateOrderMapper()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<OrderItemBase, OrderItem>();

        }

    }
}