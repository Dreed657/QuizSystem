using System.Collections.Generic;
using Server.Models.ExamAttempt;

namespace Server.Models.Profile
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ExamAttemptViewModel> Exams { get; set; }
    }
}
