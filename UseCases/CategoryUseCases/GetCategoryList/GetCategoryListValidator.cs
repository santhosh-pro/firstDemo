using FluentValidation;

namespace firstDemo.UseCases.CategoryUseCases.GetCategoryList
{
    public class GetCategoryListValidator: AbstractValidator<GetCategoryListRequest> {
        public GetCategoryListValidator () {
        }
    }
}