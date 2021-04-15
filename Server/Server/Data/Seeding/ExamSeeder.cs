﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data.Models;
using Server.Data.Models.Enums;
using Server.Data.Seeding.Contracts;

namespace Server.Data.Seeding
{
    public class ExamSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Exams.Any())
            {
                var questions = await this.SeedQuestionsAsync(dbContext, 5);

                var exam = new Exam()
                {
                    Name = "Test Exam (Seeded)",
                    EntryCode = "test",
                    Duration = TimeSpan.FromMinutes(5)
                };

                foreach (var question in questions)
                {
                    exam.Questions.Add(new ExamQuestion()
                    {
                        Question = question
                    });   
                }

                await dbContext.Exams.AddAsync(exam);
                await dbContext.SaveChangesAsync();
            }
        }

        private async Task<List<Question>> SeedQuestionsAsync(ApplicationDbContext dbContext, int count)
        {
            var questions = new List<Question>();
            var random = new Random();
            var types = Enum.GetValues(typeof(QuestionTypes));

            for (int i = 0; i < count; i++)
            {
                var question = new Question()
                {
                    Title = $"Test question {i}",
                    Type = (QuestionTypes)types.GetValue(random.Next(types.Length)),
                };
                
                question.Answers = CreateAnswers(random.Next(2, 5));
                questions.Add(question);
            }
            
            await dbContext.Questions.AddRangeAsync(questions);
            await dbContext.SaveChangesAsync();

            return questions;
        }

        private ICollection<Answer> CreateAnswers(int count)
        {
            var answers = new List<Answer>();
            var random = new Random();
            var difficulties = Enum.GetValues(typeof(AnswerDifficulty));

            for (int i = 0; i < count; i++)
            {
                var answer = new Answer()
                {
                    Content = $"Random answer test {i}",
                    IsCorrect = random.Next(0, 10) < 5,
                    Difficulty = (AnswerDifficulty)difficulties.GetValue(random.Next(difficulties.Length)),
                };

                answers.Add(answer);
            }

            return answers.ToArray();
        }
    }
}
