using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Answer
{
    public class UpdateAnswerModel : IMapTo<Data.Models.Answer>
    {
        public int Id { get; set; }

        public bool IsCorrect { get; set; }


        public string Content { get; set; }
    }
}
