using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderUseCases.GetOrder
{
    [ApiController]
    [Route ("[controller]")]
    public partial class OrdersController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntityRepository<Order,string> _entityRepository;
        public OrdersController (
            IEntityRepository<Order,string> entityRepository,
            IMapper mapper) {
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id){
            var request = await _entityRepository.FindAsync (
                id
            );
            var result = _mapper.Map<GetOrderResponse> (request);
            return Ok(result);
        }
    }
}