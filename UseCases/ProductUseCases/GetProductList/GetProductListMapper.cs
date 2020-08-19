using AutoMapper;
using firstDemo.Common;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.GetProductList
{
    public class GetProductListMapper: Profile
    {
        public GetProductListMapper()
        {
            CreateMap<Product, GetProductBase> ()
            .ForMember (dest => dest.CategoryName, opt => opt.MapFrom (src => src.Category.Name));
             

            CreateMap<PagedModel<GetProductBase,string>, GetProductListResponse> ();
        }
    }
}