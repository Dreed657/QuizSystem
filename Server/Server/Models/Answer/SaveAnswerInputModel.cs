using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Answer
{
    public class SaveAnswerInputModel : IMapTo<Data.Models.Answer>
    {
        public int ExamAttemptId { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }
    }
}
