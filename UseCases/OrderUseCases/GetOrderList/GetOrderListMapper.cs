using AutoMapper;
using firstDemo.Common;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderUseCases.GetOrderList
{
    public class GetOrderListMapper : Profile
    {
        public GetOrderListMapper()
        {
            CreateMap<Order, GetOrderBase>();
            CreateMap<OrderItem,OrderItemBase>()
            .ForMember (dest => dest.ProductName, opt => opt.MapFrom (src => src.ProductName));



            CreateMap<PagedModel<GetOrderBase, string>, GetOrderListResponse>();
        }
    }
}