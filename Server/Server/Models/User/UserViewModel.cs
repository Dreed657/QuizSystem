using AutoMapper;
using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.User
{
    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ExamsAttempted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(
                    x => x.ExamsAttempted,
                    opt => opt.MapFrom(y => y.Exams.Count)
                );
        }
    }
}