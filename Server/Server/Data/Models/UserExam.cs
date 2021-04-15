using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class UserExam
    {
        public UserExam()
        {
            this.UserAnswers = new HashSet<UserAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int WrongAnswers { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
