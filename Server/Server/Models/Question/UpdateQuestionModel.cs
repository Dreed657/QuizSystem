using System.Text.Json.Serialization;
using Server.Data.Models.Enums;

namespace Server.Models.Question
{
    public class UpdateQuestionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionTypes Type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionDifficulty Difficulty { get; set; }
    }
}
