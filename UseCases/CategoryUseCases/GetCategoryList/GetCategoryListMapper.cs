using AutoMapper;
using firstDemo.Common;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.CategoryUseCases.GetCategoryList
{
    public class GetCategoryListMapper: Profile
    {
        public GetCategoryListMapper()
        {
            CreateMap<Category, GetCategoryBase> ()
            .ForMember (dest => dest.Total, opt => opt.MapFrom (src => src.Products.Count));
             

            CreateMap<PagedModel<GetCategoryBase,string>, GetCategoryListResponse> ();
        }
    }
}