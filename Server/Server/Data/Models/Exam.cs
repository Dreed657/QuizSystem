using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class Exam
    {
        public Exam()
        {
            this.Questions = new HashSet<ExamQuestion>();
            this.Participants = new HashSet<UserExam>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EntryCode { get; set; }

        public virtual ICollection<ExamQuestion> Questions { get; set; }

        public virtual ICollection<UserExam> Participants { get; set; }
    }
}
