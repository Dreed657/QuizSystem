using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Models;
using Server.Infrastructure.Mappings;
using Server.Models.Answer;
using Server.Models.Common;
using Server.Models.Question;

namespace Server.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public QuestionService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<QuestionViewModel> GetById(int id)
        {
            return await this.db.Questions
                .To<QuestionViewModel>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAll()
        {
            return await this.db.Questions
                .To<QuestionViewModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAllAddable(int examId)
        {
            return await this.db.Questions
                .Where(x => x.Exams.All(y => y.ExamId != examId))
                .To<QuestionViewModel>()
                .ToListAsync();
            ;
        }

        // REFACTOR 
        public async Task<IEnumerable<QuestionViewModel>> GetAllByExam(int examId)
        {
            return await this.db.Exams
                .Where(x => x.Id == examId)
                .Select(x => x.Questions)
                .To<QuestionViewModel>()
                .ToListAsync();
        }

        public async Task<QuestionViewModel> Create(CreateQuestionModel model)
        {
            var question = new Question()
            {
                Title = model.Title,
                Type = model.Type,
                Difficulty = model.Difficulty,
            };

            await this.db.AddAsync(question);
            await this.db.SaveChangesAsync();

            return this.mapper.Map<QuestionViewModel>(question);
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
            entity.Difficulty = model.Difficulty;

            await this.db.SaveChangesAsync();

            return this.mapper.Map<QuestionViewModel>(entity);
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