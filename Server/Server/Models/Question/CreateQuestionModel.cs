using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data.Models.Enums;

namespace Server.Models.Question
{
    public class CreateQuestionModel
    {
        public string Title { get; set; }

        public QuestionTypes Type { get; set; }
    }
}
