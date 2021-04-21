using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class AttemptAnswer
    {
        [Key]
        public int Id { get; set; }

        public int AttemptQuestionId { get; set; }
        
        public virtual AttemptQuestion AttemptQuestion { get; set; }

        public int AnswerId { get; set; }
     
        public virtual Answer Answer { get; set; }
    }
}
