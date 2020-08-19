using AutoMapper;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.UpdateProduct
{
    public class UpdateProductMapper: Profile
    {
        public UpdateProductMapper()
        {
            CreateMap<UpdateProductRequest, Product> ();
        }
    }
}