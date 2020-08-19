using AutoMapper;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.CategoryUseCases.UpdateCategory
{
    public class UpdateCategoryMapper: Profile
    {
        public UpdateCategoryMapper()
        {
            CreateMap<UpdateCategoryRequest, Category> ();
        }
    }
}