using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.UpdateProduct
{
    [ApiController]
    [Route ("[controller]")]
    public partial class ProductsController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEntityRepository<Product,string> _entityRepository;

        public ProductsController (
            IUnitOfWork unitOfWork,
            IEntityRepository<Product,string> entityRepository,
            IMapper mapper
            ) {
            _unitOfWork = unitOfWork;
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> Update ([FromBody] UpdateProductRequest request, string id) {
            var item = _mapper.Map<Product> (request);
                item.SetId(id);
            _entityRepository.Edit (item);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}