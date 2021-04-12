using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class ExamQuestion
    {
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        public int QuestionId { get; set; }
        
        public virtual Question Question { get; set; }
    }
}
