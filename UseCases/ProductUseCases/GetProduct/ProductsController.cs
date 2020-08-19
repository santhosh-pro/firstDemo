using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.GetProduct
{
    [ApiController]
    [Route ("[controller]")]
    public partial class ProductsController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntityRepository<Product,string> _entityRepository;
        public ProductsController (
            IEntityRepository<Product,string> entityRepository,
            IMapper mapper) {
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id){
            var request = await _entityRepository.FindAsync (
                id
            );
            var result = _mapper.Map<GetProductResponse> (request);
            return Ok(result);
        }
    }
}