using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data.Models.Enums;

namespace Server.Models.Question
{
    public class ShortQuestionModel
    {
        public string Title { get; set; }

        public QuestionTypes Type { get; set; }

        public int Answers { get; set; }
    }
}
