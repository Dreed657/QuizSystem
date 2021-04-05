using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Data.Models.Enums;

namespace Server.Data.Models
{
    public class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
            this.Exams = new HashSet<Exam>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public QuestionTypes Type { get; set; }

        // AFTER EF CORE 5.0 auto creates mapping table
        public ICollection<Exam> Exams { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
