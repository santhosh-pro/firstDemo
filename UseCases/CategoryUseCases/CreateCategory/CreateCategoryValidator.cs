using FluentValidation;

namespace firstDemo.UseCases.CategoryUseCases.CreateCategory
{
    public class CreateCategoryValidator: AbstractValidator<CreateCategoryRequest> {
        public CreateCategoryValidator () {
        }
    }
}