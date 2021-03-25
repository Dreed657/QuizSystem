using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class Exam
    {
        public Exam()
        {
            this.Questions = new HashSet<Question>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EntryCode { get; set; }

        public bool IsProtected { get; set; }

        public string? Password { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
