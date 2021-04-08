namespace Server.Models.Answer
{
    public class UpdateAnswerModel
    {
        public int Id { get; set; }

        public bool IsCorrect { get; set; }


        public string Content { get; set; }
    }
}
