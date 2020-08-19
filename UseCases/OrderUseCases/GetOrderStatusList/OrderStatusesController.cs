using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderStatusUseCases.GetOrderStatusList
{
    [ApiController]
    [Route("[controller]")]
    public partial class OrderStatusesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPagingRepository<OrderStatus, int> _entityRepository;
        public OrderStatusesController(
            IPagingRepository<OrderStatus, int> entityRepository,
            IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetPaged([FromQuery] GetOrderStatusListRequest request)
        {
            var filter = PredicateBuilder.True<OrderStatus>();


            var response = await _entityRepository.GetPagedAsync<GetOrderStatusBase>(

            request.PageNumber,
            request.PageSize,
            request.OrderByPropertyName,
            request.SortingDirection,
            filter
        );

            var result = _mapper.Map<GetOrderStatusListResponse>(response);
            return Ok(result);
        }
    }
}