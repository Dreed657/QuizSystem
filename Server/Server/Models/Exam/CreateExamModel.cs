using System;

namespace Server.Models.Exam
{
    public class CreateExamModel
    {
        public string Name { get; set; }

        public string EntryCode { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
