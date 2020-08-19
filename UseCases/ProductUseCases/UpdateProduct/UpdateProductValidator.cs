using FluentValidation;

namespace firstDemo.UseCases.ProductUseCases.UpdateProduct
{
    public class UpdateProductValidator: AbstractValidator<UpdateProductRequest> {
        public UpdateProductValidator () {
        }
    }
}