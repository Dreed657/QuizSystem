using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Models;
using Server.Models.Answer;
using Server.Models.Common;
using Server.Models.Question;

namespace Server.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext db;

        public QuestionService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<QuestionViewModel> GetById(int id)
        {
            return await this.db.Questions.Select(x => new QuestionViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Type = x.Type,
                Answers = x.Answers.Select(a => new AnswerViewModel()
                {
                    Id = a.Id,
                    Content = a.Content,
                    QuestionId = a.QuestionId
                }).ToList()
            })
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        // REFACTOR 
        public async Task<IEnumerable<QuestionViewModel>> GetAllForExam(int examId)
        {
            var exam = await this.db.Exams
                .Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x.Id == examId);

            return exam?.Questions.Select(x => new QuestionViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Type = x.Type,
                    Answers = x.Answers.Select(a => new AnswerViewModel()
                    {
                        Id = a.Id,
                        Content = a.Content,
                        QuestionId = a.QuestionId
                    }).ToList()
            })
                .ToList();
        }

        public async Task<bool> AddAnswer(AddAnswerToQuestion model)
        {
            var question = await this.db.Questions.FirstOrDefaultAsync(x => x.Id == model.QuestionId);
            var answer = await this.db.Answers.FirstOrDefaultAsync(x => x.Id == model.AnswerId);

            if (question == null)
            {
                return false;
            }

            if (answer == null)
            {
                return false;
            }

            question.Answers.Add(answer);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<QuestionViewModel> Create(CreateQuestionModel model)
        {
            var question = new Question()
            {
                Title = model.Title,
                Type = model.Type
            };

            await this.db.AddAsync(question);
            await this.db.SaveChangesAsync();

            return new QuestionViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Type = question.Type,
                Answers = question.Answers.Select(a => new AnswerViewModel()
                {
                    Id = a.Id,
                    Content = a.Content,
                    QuestionId = a.QuestionId
                }).ToList()
            };
        }

        public async Task<QuestionViewModel> Update(UpdateQuestionModel model)
        {
            var entity = await this.db.Questions.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                return null;
            }

            entity.Title = model.Title;
            entity.Type = model.Type;

            await this.db.SaveChangesAsync();

            return new QuestionViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Type = entity.Type,
                Answers = entity.Answers.Select(a => new AnswerViewModel()
                {
                    Id = a.Id,
                    Content = a.Content,
                    QuestionId = a.QuestionId
                }).ToList()
            };
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await this.db.Questions.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            this.db.Questions.Remove(entity);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
