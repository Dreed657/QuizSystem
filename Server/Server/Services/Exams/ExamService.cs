using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Models;
using Server.Models.Answer;
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
                .Select(x => new ShortExamModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Questions = x.Questions.Count
                })
                .ToListAsync();
        }

        public async Task<ExamViewModel> GetById(int id)
        {
            var entity = await this.db.Exams
                .Include(x => x.Questions)
                .ThenInclude(x => x.Question.Answers)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ExamViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryCode = entity.EntryCode,
                Questions = entity.Questions.Select(x => new ShortQuestionModel()
                {
                    Id = x.Question.Id,
                    Title = x.Question.Title,
                    Type = x.Question.Type.ToString(),
                    Answers = x.Question.Answers.Count()
                }).ToList()
            };
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
                // Password = model.Password
            };

            await this.db.Exams.AddAsync(entity);
            await this.db.SaveChangesAsync();

            return new ExamViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryCode = entity.EntryCode,
                Questions = entity.Questions.Select(x => new ShortQuestionModel()
                {
                    Id = x.Question.Id,
                    Title = x.Question.Title,
                    Type = x.Question.Type.ToString(),
                    Answers = x.Question.Answers.Count(),
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

            await db.SaveChangesAsync();

            return new ExamViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryCode = entity.EntryCode,
                Questions = entity.Questions.Select(x => new ShortQuestionModel()
                {
                    Id = x.Question.Id,
                    Title = x.Question.Title,
                    Type = x.Question.Type.ToString(),
                    Answers = x.Question.Answers.Count()
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

        public async Task<bool> Join(string userId, int examId)
        {
            var exam = await this.db.Exams.FirstOrDefaultAsync(x => x.Id == examId);

            if (exam == null)
            {
                return false;
            }

            var user = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return false;
            }

            exam.Participants.Add(new UserExam()
            {
                Exam = exam,
                User = user
            });
            await this.db.SaveChangesAsync();

            return true;
        }

        // TODO: LOOK UP THIS
        public async Task Finish(string userId, int examId)
        {
            var entity = await this.db.ExamParticipants.FirstOrDefaultAsync(x => x.ExamId == examId && x.UserId == userId);
            var results = await this.db.UserAnswer.Where(x => x.UserId == userId && x.ExamId == examId).ToListAsync();

            var correct = results.Count(x => x.Answer.IsCorrect);
            var wrong = results.Count - correct;
            var score = results.Select(x => x.Answer.Difficulty).Cast<int>().Sum();

            entity.Score = score;
            entity.CorrectAnswers = correct;
            entity.WrongAnswers = wrong;

            await this.db.SaveChangesAsync();
        }
    }
}