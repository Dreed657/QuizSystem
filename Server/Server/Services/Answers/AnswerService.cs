using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Models;
using Server.Data.Models.Enums;
using Server.Infrastructure.Mappings;
using Server.Models.Answer;

namespace Server.Services.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public AnswerService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<AnswerViewModel> GetById(int id)
        {
            return await this.db.Answers
                .To<AnswerViewModel>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AnswerViewModel>> GetByQuestionId(int id)
        {
            return await this.db.Answers
                .Where(x => x.Question.Id == id)
                .To<AnswerViewModel>()
                .ToListAsync();
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

            return this.mapper.Map<AnswerViewModel>(answer);
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

            return this.mapper.Map<AnswerViewModel>(entity);
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

        // TODO: Add error text responses | Refactor this to be more resource efficient 
        public async Task<bool> SaveAnswer(string userId, SaveAnswerInputModel model)
        {
            var examAttempt = await this.db.ExamParticipants
                .Where(x => x.Status == ExamStatus.Started)
                .FirstOrDefaultAsync(x => x.Id == model.ExamAttemptId);

            if (examAttempt == null)
            {
                return false;
            }

            if (examAttempt.UserId != userId)
            {
                return false;
            }

            var question = await this.db.Questions
                .Include(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Id == model.QuestionId);

            if (question == null)
            {
                return false;
            }

            if (question.Answers.All(x => x.Id != model.AnswerId))
            {
                return false;
            }

            var attemptQuestionId = await this.db.AttemptQuestions
                .Where(x => x.ExamAttemptId == examAttempt.Id && x.QuestionId == question.Id)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            // If cannot find attempt in db
            // 0 is default value
            if (attemptQuestionId != 0)
            {
                var attemptAnswers = this.db.AttemptAnswers
                    .Where(x => x.AttemptQuestionId == attemptQuestionId);

                if (attemptAnswers.All(x => x.Answer.Id != model.AnswerId))
                {
                    var answer = new AttemptAnswer()
                    {
                        AttemptQuestionId = attemptQuestionId,
                        AnswerId = model.AnswerId
                    };

                    await this.db.AttemptAnswers.AddAsync(answer);
                }
            }
            else
            {
                var questionAttempt = new AttemptQuestion()
                {
                    ExamAttempt = examAttempt,
                    QuestionId = question.Id
                };

                var answerAttempt = new AttemptAnswer()
                {
                    AnswerId = model.AnswerId
                };

                questionAttempt.Answers.Add(answerAttempt);
                await this.db.AttemptQuestions.AddAsync(questionAttempt);
            }

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}