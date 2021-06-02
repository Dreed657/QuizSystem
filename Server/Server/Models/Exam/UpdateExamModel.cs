using Server.Infrastructure.Mappings.Contracts;

namespace Server.Models.Exam
{
    public class UpdateExamModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryCode { get; set; }
     
        public string Duration { get; set; }
    }
}
