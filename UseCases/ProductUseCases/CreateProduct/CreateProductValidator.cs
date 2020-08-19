using System.Data;
using FluentValidation;

namespace firstDemo.UseCases.ProductUseCases.CreateProduct
{
    public class CreateProductValidator: AbstractValidator<CreateProductRequest> {
        public CreateProductValidator () {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is Required");
        }
    }
}