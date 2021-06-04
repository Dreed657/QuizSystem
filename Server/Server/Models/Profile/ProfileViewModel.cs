using System.Collections.Generic;
using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;
using Server.Models.ExamAttempt;

namespace Server.Models.Profile
{
    public class ProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ExamAttemptViewModel> Exams { get; set; }
    }
}
