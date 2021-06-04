using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.User
{
    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ExamsAttempted { get; set; }
    }
}
