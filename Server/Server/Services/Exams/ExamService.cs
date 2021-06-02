using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Models;
using Server.Data.Models.Enums;
using Server.Infrastructure.Mappings;
using Server.Models.Common;
using Server.Models.Exam;
using Server.Models.Question;

namespace Server.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext db;

        public ExamService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ShortExamModel>> GetAll()
        {
            return await this.db.Exams
                .To<ShortExamModel>()
                .ToListAsync();
        }

        public async Task<ExamViewModel> GetById(int id)
        {
            return await this.db.Exams
                .Include(x => x.Questions)
                .ThenInclude(x => x.Question.Answers)
                .To<ExamViewModel>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AddQuestion(AddQuestionInputModel model)
        {
            var exam = await this.db.Exams.FirstOrDefaultAsync(x => x.Id == model.ExamId);
            var question = await this.db.Questions.FirstOrDefaultAsync(x => x.Id == model.QuestionId);

            if (exam == null)
            {
                return false;
            }

            if (question == null)
            {
                return false;
            }

            exam.Questions.Add(new ExamQuestion()
            {
                Question = question
            });
            await this.db.SaveChangesAsync();

            return true;
        }

        // TODO: Replace include with better solution
        public async Task<bool> RemoveQuestion(RemoveQuestionInputModel model)
        {
            var examQuestion = await
                this.db.ExamQuestion.FirstOrDefaultAsync(x =>
                    x.ExamId == model.ExamId && x.QuestionId == model.QuestionId);

            if (examQuestion == null)
            {
                return false;
            }

            this.db.ExamQuestion.Remove(examQuestion);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<ExamViewModel> Create(CreateExamModel model)
        {
            var entity = new Exam()
            {
                Name = model.Name,
                EntryCode = model.EntryCode,
                Duration = TimeSpan.Parse(model.Duration)
            };

            await this.db.Exams.AddAsync(entity);
            await this.db.SaveChangesAsync();

            return new ExamViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryCode = entity.EntryCode,
                Duration = entity.Duration.ToString(),
                Questions = entity.Questions.Select(x => new ShortQuestionModel()
                {
                    //Id = x.Question.Id,
                    //Title = x.Question.Title,
                    //Type = x.Question.Type.ToString(),
                    //Answers = x.Question.Answers.Count(),
                }).ToList()
            };
        }

        public async Task<ExamViewModel> Update(UpdateExamModel model)
        {
            var entity = await this.db.Exams.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                return null;
            }

            entity.Name = model.Name;
            entity.EntryCode = model.EntryCode;
            entity.Duration = TimeSpan.Parse(model.Duration);

            await db.SaveChangesAsync();

            return new ExamViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryCode = entity.EntryCode,
                Duration = entity.Duration.ToString(),
                Questions = entity.Questions.Select(x => new ShortQuestionModel()
                {
                    //Id = x.Question.Id,
                    //Title = x.Question.Title,
                    //Type = x.Question.Type.ToString(),
                    //Answers = x.Question.Answers.Count()
                }).ToList()
            };
        }

        public async Task<bool> Delete(int examId)
        {
            var entity = await this.db.Exams.FirstOrDefaultAsync(x => x.Id == examId);

            if (entity == null)
            {
                return false;
            }

            this.db.Exams.Remove(entity);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<StartExamModel> Start(string userId, int examId)
        {
            var exam = await this.db.Exams.FirstOrDefaultAsync(x => x.Id == examId);

            if (exam == null)
            {
                return null;
            }

            var user = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return null;
            }

            var entity = new UserExam()
            {
                Exam = exam,
                User = user,
                StartTime = DateTime.UtcNow,
                Status = ExamStatus.Started
            };

            await this.db.ExamParticipants.AddAsync(entity);
            await this.db.SaveChangesAsync();

            return new StartExamModel()
            {
                ExamAttemptId = entity.Id
            };
        }

        // TODO: LOOK UP THIS | Refactor this to be more efficient
        public async Task<FinishExamModel> Finish(string userId, int examId)
        {
            if (examId == 0)
            {
                return null;
            }

            var examAttempt = await this.db.ExamParticipants
                .Where(x => x.Status == ExamStatus.Started)
                .FirstOrDefaultAsync(x => x.ExamId == examId && x.UserId == userId);

            var results = await this.db.AttemptQuestions
                .Where(x => x.ExamAttemptId == examAttempt.Id)
                .SelectMany(x => x.Answers)
                .Include(x => x.Answer)
                .Include(x => x.AttemptQuestion)
                .ToListAsync();
            
            var total = results.Count;
            var correct = results.Count(x => x.Answer.IsCorrect);
            var wrong = total - correct;
            var score = results
                .Where(x => x.Answer.IsCorrect)
                .Select(x => x.AttemptQuestion.Question.Difficulty)
                .Cast<int>()
                .Sum();

            examAttempt.Score = score;
            examAttempt.CorrectAnswers = correct;
            examAttempt.WrongAnswers = wrong;
            examAttempt.EndTime = DateTime.UtcNow;
            examAttempt.Status = ExamStatus.Finished;

            await this.db.SaveChangesAsync();

            return new FinishExamModel()
            {
                Score = examAttempt.Score,
                CorrectAnswers = examAttempt.CorrectAnswers,
                WrongAnswers = examAttempt.WrongAnswers,
                StartTime = examAttempt.StartTime,
                EndTime = examAttempt.EndTime
            };
        }
    }
}