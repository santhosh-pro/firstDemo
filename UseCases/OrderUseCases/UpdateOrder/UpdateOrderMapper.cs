using AutoMapper;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderUseCases.UpdateOrder
{
    public class UpdateOrderMapper: Profile
    {
        public UpdateOrderMapper()
        {
            CreateMap<UpdateOrderRequest, Order> ();
        }
    }
}