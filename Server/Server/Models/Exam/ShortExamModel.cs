using AutoMapper;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Exam
{
    public class ShortExamModel : IMapFrom<Data.Models.Exam>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public int Questions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Exam, ShortExamModel>()
                .ForMember(
                    x => x.Questions,
                    opt => opt.MapFrom(y => y.Questions.Count)
                );
        }
    }
}