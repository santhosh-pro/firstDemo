using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.DeleteProduct
{   [ApiController]
    [Route ("[controller]")]
    public partial class ProductsController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntityRepository<Product, string> _entityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(
            IEntityRepository<Product, string> entityRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var request = _entityRepository.Find(id);
            _entityRepository.Delete(request);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    
    }
}