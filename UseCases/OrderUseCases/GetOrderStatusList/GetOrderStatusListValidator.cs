using FluentValidation;

namespace firstDemo.UseCases.OrderStatusUseCases.GetOrderStatusList
{
    public class GetOrderStatusListValidator: AbstractValidator<GetOrderStatusListRequest> {
        public GetOrderStatusListValidator () {
        }
    }
}