﻿using System.Collections.Generic;
using Server.Models.Question;

namespace Server.Models.Exam
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryCode { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
