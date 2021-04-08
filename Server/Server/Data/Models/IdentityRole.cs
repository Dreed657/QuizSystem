using System;
using Microsoft.AspNetCore.Identity;

namespace Server.Data.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
