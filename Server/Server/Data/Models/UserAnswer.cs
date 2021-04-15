using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        public int ExamAttemptId { get; set; }

        public virtual UserExam ExamAttempt { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }
        
        public virtual Answer Answer { get; set; }
    }
}
