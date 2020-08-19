using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderStatusUseCases.GetOrderStatus
{
    [ApiController]
    [Route ("[controller]")]
    public partial class OrderStatusesController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntityRepository<OrderStatus,int> _entityRepository;
        public OrderStatusesController (
            IEntityRepository<OrderStatus,int> entityRepository,
            IMapper mapper) {
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpGet("status/{id}")]
        public async Task<IActionResult> Get(int id){
            var request = await _entityRepository.FindAsync (
                id
            );
            var result = _mapper.Map<GetOrderStatusResponse> (request);
            return Ok(result);
        }
    }
}