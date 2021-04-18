using System;
using System.Collections.Generic;
using Server.Models.Question;

namespace Server.Models.Exam
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryCode { get; set; }

        public string Duration { get; set; }

        public string DurationInMs { get; set; }

        public ICollection<ShortQuestionModel> Questions { get; set; }
    }
}
