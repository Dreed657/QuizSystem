using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Answer
{
    public class CreateAnswerModel : IMapTo<Data.Models.Answer>
    {
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
