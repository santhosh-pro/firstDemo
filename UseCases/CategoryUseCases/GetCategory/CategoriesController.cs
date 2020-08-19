using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.CategoryUseCases.GetCategory
{
    [ApiController]
    [Route ("[controller]")]
    public partial class CategoriesController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntityRepository<Category,string> _entityRepository;
        public CategoriesController (
            IEntityRepository<Category,string> entityRepository,
            IMapper mapper) {
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id){
            var request = await _entityRepository.FindAsync (
                id
            );
            var result = _mapper.Map<GetCategoryResponse> (request);
            return Ok(result);
        }
    }
}