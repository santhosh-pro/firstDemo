using FluentValidation;

namespace firstDemo.UseCases.ProductUseCases.GetProductList
{
    public class GetProductListValidator: AbstractValidator<GetProductListRequest> {
        public GetProductListValidator () {
        }
    }
}