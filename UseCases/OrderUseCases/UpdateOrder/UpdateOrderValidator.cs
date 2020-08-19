using FluentValidation;

namespace firstDemo.UseCases.OrderUseCases.UpdateOrder
{
    public class UpdateOrderValidator: AbstractValidator<UpdateOrderRequest> {
        public UpdateOrderValidator () {
        }
    }
}