using AutoMapper;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.CategoryUseCases.CreateCategory
{
    public class CreateCategoryMapper: Profile
    {
        public CreateCategoryMapper()
        {
            CreateMap<CreateCategoryRequest, Category> ();
        }
        
    }
}