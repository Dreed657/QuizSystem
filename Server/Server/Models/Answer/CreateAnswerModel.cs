namespace Server.Models.Answer
{
    public class CreateAnswerModel
    {
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
