using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }
        
        public virtual Answer Answer { get; set; }
    }
}
