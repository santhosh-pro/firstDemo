using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.CategoryUseCases.GetCategoryList
{
    [ApiController]
    [Route("[controller]")]
    public partial class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPagingRepository<Category, string> _entityRepository;
        public CategoriesController(
            IPagingRepository<Category, string> entityRepository,
            IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] GetCategoryListRequest request)
        {
            var filter = PredicateBuilder.True<Category>();

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                filter = filter.And(x => x.Name.ToLower().Contains(request.SearchKey.ToLower()));
            }
            var response = await _entityRepository.GetPagedAsync<GetCategoryBase>(

            request.PageNumber,
            request.PageSize,
            request.OrderByPropertyName,
            request.SortingDirection,
            filter,
            x=>x.Products
        );

            var result = _mapper.Map<GetCategoryListResponse>(response);
            return Ok(result);
        }
    }
}