﻿using System;
using Server.Data.Models;
using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.ExamAttempt
{
    public class ExamAttemptViewModel : IMapFrom<UserExam>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ExamName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int WrongAnswers { get; set; }

    }
}
