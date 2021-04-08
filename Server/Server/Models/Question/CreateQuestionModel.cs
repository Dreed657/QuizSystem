using System.Text.Json.Serialization;
using Server.Data.Models.Enums;

namespace Server.Models.Question
{
    public class CreateQuestionModel
    {
        public string Title { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionTypes Type { get; set; }
    }
}
