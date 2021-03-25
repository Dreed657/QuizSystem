using System.Collections.Generic;
using Server.Data.Models.Enums;
using Server.Models.Answer;

namespace Server.Models.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public QuestionTypes Type { get; set; }

        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}
