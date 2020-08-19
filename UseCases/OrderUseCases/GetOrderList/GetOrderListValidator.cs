using FluentValidation;

namespace firstDemo.UseCases.OrderUseCases.GetOrderList
{
    public class GetOrderListValidator: AbstractValidator<GetOrderListRequest> {
        public GetOrderListValidator () {
        }
    }
}