using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Exam
{
    public class UpdateExamModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryCode { get; set; }
     
        public TimeSpan Duration { get; set; }
    }
}
