using FluentValidation;

namespace firstDemo.UseCases.OrderUseCases.CreateOrder
{
    public class CreateOrderValidator: AbstractValidator<CreateOrderRequest> {
        public CreateOrderValidator () {
        }
    }
}