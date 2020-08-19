using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.OrderUseCases.CreateOrder
{
    [ApiController]
    [Route("[controller]")]
    public partial class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEntityRepository<Order, string> _entityRepository;
        private readonly IEntityRepository<Product, string> _entityProductRepository;

        public OrdersController(
            IUnitOfWork unitOfWork,
            IEntityRepository<Order, string> entityRepository,
            IEntityRepository<Product, string> entityProductRepository,
            IMapper mapper
                        )
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
            _entityProductRepository = entityProductRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var item = _mapper.Map<Order>(request);
            item.MakeOrderCreated();
            foreach (var ite in item.OrderItems)
            {
                var product = await _entityProductRepository.FindAsync(ite.ProductId);
                ite.SetProductName(product.Name);
                ite.SetUnitPrice(product.Price);
                ite.AddTotalPrice();
            }
            await _entityRepository.AddAsync(item);
            await _unitOfWork.CompleteAsync();
            return Ok(item);
        }
    }
}