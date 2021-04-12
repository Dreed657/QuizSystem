using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class UserExam
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        public int Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int WrongAnswers { get; set; }
    }
}
