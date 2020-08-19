using AutoMapper;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.ProductUseCases.GetProduct
{
    public class GetProductMapper: Profile
    {
        public GetProductMapper()
        {
            CreateMap<Product,GetProductResponse> ();
        }
    }
}