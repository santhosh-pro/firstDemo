using AutoMapper;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.CategoryUseCases.GetCategory
{
    public class GetCategoryMapper: Profile
    {
        public GetCategoryMapper()
        {
            CreateMap<Category,GetCategoryResponse> ();
        }
    }
}