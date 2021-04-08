using System;
using Microsoft.AspNetCore.Identity;

namespace Server.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
