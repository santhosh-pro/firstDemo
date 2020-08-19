using AutoMapper;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.CreateProduct
{
    public class CreateProductMapper: Profile
    {
        public CreateProductMapper()
        {
            CreateMap<CreateProductRequest, Product> ();
        }
        
    }
}