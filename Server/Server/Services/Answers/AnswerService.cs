using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Models;
using Server.Models.Answer;

namespace Server.Services.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext db;

        public AnswerService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<AnswerViewModel> GetById(int id)
        {
            var entity = await this.db.Answers.FirstOrDefaultAsync(x => x.Id == id);

            return new AnswerViewModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                IsCorrect = entity.IsCorrect,
                QuestionId = entity.QuestionId
            };
        }

        public async Task<IEnumerable<AnswerViewModel>> GetByQuestionId(int id)
        {
            var entity = await this.db.Questions
                .Include(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity?.Answers.Select(x => new AnswerViewModel()
            {
                Id = x.Id,
                Content = x.Content,
                IsCorrect = x.IsCorrect,
                QuestionId = x.QuestionId
            }).ToList();
        }

        public async Task<AnswerViewModel> Create(CreateAnswerModel model)
        {
            var answer = new Answer()
            {
                Content = model.Content,
                IsCorrect = model.IsCorrect,
                QuestionId = model.QuestionId
            };

            await this.db.Answers.AddAsync(answer);
            await this.db.SaveChangesAsync();

            return new AnswerViewModel()
            {
                Id = answer.Id,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId
            };
        }

        public async Task<AnswerViewModel> Update(UpdateAnswerModel model)
        {
            var entity = await this.db.Answers.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                return null;
            }

            entity.Content = model.Content;
            entity.IsCorrect = model.IsCorrect;

            await this.db.SaveChangesAsync();

            return new AnswerViewModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                IsCorrect = entity.IsCorrect,
                QuestionId = entity.QuestionId
            };
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await this.db.Answers.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            this.db.Answers.Remove(entity);
            await this.db.SaveChangesAsync();

            return true;
        }

        // TODO: Add error responses
        public async Task<bool> SaveAnswer(string userId, SaveAnswerInputModel model)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var examAttempt = await this.db.ExamParticipants.FirstOrDefaultAsync(x =>
                x.ExamId == model.ExamId && x.UserId == userId);

            if (examAttempt == null)
            {
                return false;
            }

            var question = await this.db.Questions.FirstOrDefaultAsync(x => x.Id == model.QuestionId);

            if (question == null)
            {
                return false;
            }

            if (question.Answers.Any(x => x.Id == model.AnswerId))
            {
                return false;
            }

            var entity = new UserAnswer()
            {
                ExamAttempt = examAttempt,
                Question = question,
                AnswerId = model.AnswerId
            };

            await this.db.UserAnswer.AddAsync(entity);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
