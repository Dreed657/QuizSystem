using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data.Models.Enums;

namespace Server.Models.Question
{
    public class ShortQuestionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Difficulty { get; set; }

        public int Answers { get; set; }
    }
}
