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
                QuestionId = x.QuestionId
            }).ToList();
        }

        public async Task<AnswerViewModel> Create(CreateAnswerModel model)
        {
            var answer = new Answer()
            {
                Content = model.Content,
                QuestionId = model.QuestionId
            };

            await this.db.Answers.AddAsync(answer);
            await this.db.SaveChangesAsync();

            return new AnswerViewModel()
            {
                Id = answer.Id,
                Content = answer.Content,
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

            return new AnswerViewModel()
            {
                Id = entity.Id,
                Content = entity.Content,
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
    }
}
