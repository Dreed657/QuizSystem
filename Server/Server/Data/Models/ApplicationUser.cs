using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Server.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<UserExam> Exams { get; set; }
    }
}
