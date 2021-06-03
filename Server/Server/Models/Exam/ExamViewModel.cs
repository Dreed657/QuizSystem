using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Server.Infrastructure.Mappings.Contracts;
using Server.Models.Question;

namespace Server.Models.Exam
{
    public class ExamViewModel : IMapFrom<Data.Models.Exam>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryCode { get; set; }

        public string Duration { get; set; }

        public string DurationInMs { get; set; }

        public ICollection<ShortQuestionModel> Questions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Exam, ExamViewModel>()
                .ForMember(
                    x => x.Questions, 
                    opt => opt.MapFrom(
                        y => y.Questions.Select(q => q.Question)
                        )
                    );
        }
    }
}
