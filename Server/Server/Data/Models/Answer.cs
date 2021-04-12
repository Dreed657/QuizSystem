using System.ComponentModel.DataAnnotations;
using Server.Data.Models.Enums;

namespace Server.Data.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(25)]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public AnswerDifficulty Difficulty { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
