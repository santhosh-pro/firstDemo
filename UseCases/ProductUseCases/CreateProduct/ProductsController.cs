using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;
using firstDemo.Common;

namespace firstDemo.UseCases.ProductUseCases.CreateProduct
{
    [ApiController]
    [Route("[controller]")]
    public partial class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEntityRepository<Product, string> _entityRepository;

        public ProductsController(
            IUnitOfWork unitOfWork,
            IEntityRepository<Product, string> entityRepository,
            IMapper mapper
                        )
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            if (await _entityRepository.HasMatchingAsync(x => x.Name == request.Name))
                throw new UseCaseException("Name Already Exists");

            var item = _mapper.Map<Product>(request);
            await _entityRepository.AddAsync(item);
            await _unitOfWork.CompleteAsync();
            return Ok(item);
        }
    }
}