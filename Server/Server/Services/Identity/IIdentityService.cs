using System.Collections.Generic;

namespace Server.Services.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, IList<string> roles, string secret);
    }
}
