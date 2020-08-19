using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderUseCases.GetOrderList
{
    [ApiController]
    [Route("[controller]")]
    public partial class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPagingRepository<Order, string> _entityRepository;
        public OrdersController(
            IPagingRepository<Order, string> entityRepository,
            IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] GetOrderListRequest request)
        {
            var filter = PredicateBuilder.True<Order>();


            var response = await _entityRepository.GetPagedAsync<GetOrderBase>(

            request.PageNumber,
            request.PageSize,
            request.OrderByPropertyName,
            request.SortingDirection,
            filter,
            x=>x.OrderItems
        );

            var result = _mapper.Map<GetOrderListResponse>(response);
            return Ok(result);
        }
    }
}