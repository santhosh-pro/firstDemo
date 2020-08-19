using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common.Helpers.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null)
            { }
            else
            {
                this.IsAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
                if (this.IsAuthenticated)
                {
                    this.UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                    this.TenantId = httpContextAccessor.HttpContext?.User?.FindFirstValue("tenantId");
                }
            }

        }

        public string UserId { get; }
        public string TenantId { get; set; }
        public bool IsAuthenticated { get; set; }

    }
}