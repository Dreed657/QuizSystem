using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;
using Server.Models.ExamAttempt;

namespace Server.Models.Profile
{
    public class ProfileViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double AvgGPA { get; set; }

        public ICollection<ExamAttemptViewModel> Exams { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(
                    x => x.AvgGPA,
                    opt => opt.MapFrom(
                        y => y.Exams.Any() ? y.Exams.Average(a => a.Score) : 0
                    )
                );
        }
    }
}