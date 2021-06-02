using System.Collections.Generic;
using AutoMapper;
using Server.Infrastructure.Mappings.Contracts;
using Server.Models.Question;

namespace Server.Models.Exam
{
    public class ExamViewModel : IMapFrom<Data.Models.Exam>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryCode { get; set; }

        public string Duration { get; set; }

        public string DurationInMs { get; set; }

        public ICollection<ShortQuestionModel> Questions { get; set; }
    }
}
