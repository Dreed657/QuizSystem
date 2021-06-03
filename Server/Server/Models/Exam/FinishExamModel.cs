using System;
using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Exam
{
    public class FinishExamModel : IMapFrom<UserExam>
    {
        public int Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int WrongAnswers { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
