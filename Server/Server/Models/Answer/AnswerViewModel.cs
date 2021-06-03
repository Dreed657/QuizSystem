using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Answer
{
    public class AnswerViewModel : IMapFrom<Data.Models.Answer>, IMapTo<Data.Models.Answer>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
