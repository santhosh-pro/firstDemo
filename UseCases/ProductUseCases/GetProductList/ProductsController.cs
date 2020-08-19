using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using firstDemo.Common;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence.Entities;

namespace firstDemo.UseCases.ProductUseCases.GetProductList
{
    [ApiController]
    [Route("[controller]")]
    public partial class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPagingRepository<Product, string> _entityRepository;
        public ProductsController(
            IPagingRepository<Product, string> entityRepository,
            IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] GetProductListRequest request)
        {
            var filter = PredicateBuilder.True<Product>();

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                filter = filter.And(x => x.Name == request.SearchKey);
            }

            if (!string.IsNullOrEmpty(request.CategoryId))
            {
                filter = filter.And(x => x.CategoryId == request.CategoryId);
            }

            if (request.MinPrice > 0)
            {
                filter = filter.And(x => x.Price >= request.MinPrice);
            }

            if (request.MaxPrice > 0)
            {
                filter = filter.And(x => x.Price <= request.MaxPrice);
            }

            var response = await _entityRepository.GetPagedAsync<GetProductBase>(

            request.PageNumber,
            request.PageSize,
            request.OrderByPropertyName,
            request.SortingDirection,
            filter,
            x => x.Category
        );

            var result = _mapper.Map<GetProductListResponse>(response);
            return Ok(result);
        }
    }
}