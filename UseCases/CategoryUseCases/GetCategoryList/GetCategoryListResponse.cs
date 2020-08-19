using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.UseCases.CategoryUseCases.GetCategoryList
{
    public class GetCategoryListResponse: PagedResponse
    {
         public List<GetCategoryBase> Items { get; set; }
    }
}