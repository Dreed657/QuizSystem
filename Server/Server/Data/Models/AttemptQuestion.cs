using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class AttemptQuestion
    {
        public AttemptQuestion()
        {
            this.Answers = new HashSet<AttemptAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public int ExamAttemptId { get; set; }

        public virtual UserExam ExamAttempt { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<AttemptAnswer> Answers { get; set; }
    }
}
