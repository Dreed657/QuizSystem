using AutoMapper;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Question
{
    public class ShortQuestionModel : IMapFrom<Data.Models.Question>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int Answers { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Question, ShortQuestionModel>()
                .ForMember(x => x.Answers,
                    opt => opt.MapFrom(y => y.Answers.Count)
                    );
        }
    }
}