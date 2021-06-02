using AutoMapper;
using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Question
{
    public class ShortQuestionModel : IMapFrom<Data.Models.ExamQuestion>
    {
        public int QuestionId { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionType { get; set; }

        public int QuestionAnswersCount { get; set; }
    }
}