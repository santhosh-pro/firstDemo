using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.CategoryUseCases.UpdateCategory
{
    [ApiController]
    [Route ("[controller]")]
    public partial class CategoriesController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEntityRepository<Category,string> _entityRepository;

        public CategoriesController (
            IUnitOfWork unitOfWork,
            IEntityRepository<Category,string> entityRepository,
            IMapper mapper
            ) {
            _unitOfWork = unitOfWork;
            _entityRepository=entityRepository;
            _mapper=mapper;
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> Update ([FromBody] UpdateCategoryRequest request, string id) {
            var item = _mapper.Map<Category> (request);
                item.SetId(id);
            _entityRepository.Edit (item);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}