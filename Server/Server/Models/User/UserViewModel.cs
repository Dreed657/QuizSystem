using System.Collections.Generic;

namespace Server.Models.User
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ExamsAttempted { get; set; }
    }
}
