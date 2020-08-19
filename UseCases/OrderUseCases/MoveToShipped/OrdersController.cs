using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.UseCases.MoveToShipped
{
    [ApiController]
    [Route("[controller]")]
    public partial class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<Order, string> _entityRepository;

        public OrdersController(
            IUnitOfWork unitOfWork,
            IEntityRepository<Order, string> entityRepository,
            IMapper mapper
                        )
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpPut("MoveToShipped")]
        public async Task<IActionResult> MoveToShipped(string id)
        {

            var order = await _entityRepository.FindAsync(id);
            order.MakeOrderShipped();
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}