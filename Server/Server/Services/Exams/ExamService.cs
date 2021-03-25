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
            var entity = await this.db.Exams.FirstOrDefaultAsync(x => x.Id == id);
            
            return new ExamViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryCode = entity.EntryCode,
                Questions = entity.Questions.Select(x => new QuestionViewModel()
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
                }).ToList()
            };
        }

        public async Task<ExamViewModel> GetByEntryCode(string entryCode)
        {
            var exam = await this.db.Exams.FirstOrDefaultAsync(x => x.EntryCode == entryCode);

            if (exam == null)
            {
                return null;
            }

            return new ExamViewModel()
            {
                Id = exam.Id,
                Name = exam.Name,
                EntryCode = exam.EntryCode,
                Questions = exam.Questions.Select(x => new QuestionViewModel()
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

            exam.Questions.Add(question);
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
                Questions = entity.Questions.Select(x => new QuestionViewModel()
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
                Questions = entity.Questions.Select(x => new QuestionViewModel()
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

            return true;
        }
    }
}
