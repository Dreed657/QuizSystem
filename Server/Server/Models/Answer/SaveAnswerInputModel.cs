﻿namespace Server.Models.Answer
{
    public class SaveAnswerInputModel
    {
        public int ExamId { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }
    }
}