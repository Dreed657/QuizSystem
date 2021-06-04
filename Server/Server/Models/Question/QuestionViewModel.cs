using System.Collections.Generic;
using Server.Infrastructure.Mappings.Contracts;
using Server.Models.Answer;

namespace Server.Models.Question
{
    public class QuestionViewModel : IMapFrom<Data.Models.Question>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Difficulty { get; set; }

        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}
