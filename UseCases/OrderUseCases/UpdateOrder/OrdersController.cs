using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.OrderUseCases.UpdateOrder
{
    [ApiController]
    [Route ("[controller]")]
    public partial class OrdersController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEntityRepository<Order,string> _entityRepository;

        public OrdersController (
            IUnitOfWork unitOfWork,
            IEntityRepository<Order,string> entityRepository,
            IMapper mapper
            ) {
            _unitOfWork = unitOfWork;
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> Update ([FromBody] UpdateOrderRequest request, string id) {
            var item = _mapper.Map<Order> (request);
                item.SetId(id);
            _entityRepository.Edit (item);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}