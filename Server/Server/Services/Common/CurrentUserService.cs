using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Server.Infrastructure.Extensions;

namespace Server.Services.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
        }

        public string GetUserName()
        {
            return this.user?.Identity.Name;
        }

        public string GetId()
        {
            return this.user?.GetId();
        }
    }
}
