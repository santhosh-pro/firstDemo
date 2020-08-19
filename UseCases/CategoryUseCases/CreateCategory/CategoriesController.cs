using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;
namespace firstDemo.UseCases.CategoryUseCases.CreateCategory
{
    [ApiController]
    [Route ("[controller]")]
    public partial class CategoriesController : ControllerBase
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request){
            var item= _mapper.Map<Category>(request);
            await _entityRepository.AddAsync(item);
            await _unitOfWork.CompleteAsync();
            return CreatedAtRoute ("",new {id=item.Id});
        }
    }
}