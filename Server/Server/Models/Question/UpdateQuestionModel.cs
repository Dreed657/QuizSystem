using Server.Data.Models.Enums;

namespace Server.Models.Question
{
    public class UpdateQuestionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public QuestionTypes Type { get; set; }
    }
}
