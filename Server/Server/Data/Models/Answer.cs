using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [MinLength(25)]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
