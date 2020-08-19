using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace firstDemo.Common.Helpers.Filters
{
    public class UserActivityLogger : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            try {

                // if (resultContext.HttpContext.User.Identity.IsAuthenticated)
                // {
                //     var userId = resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //     var usersRepository = resultContext.HttpContext.RequestServices.GetService<IUserRepository>();
                //
                //     await usersRepository.UpdateLastActiveTime(userId);
                // }

            }
            catch { 
                    
            }
        }
    }
}