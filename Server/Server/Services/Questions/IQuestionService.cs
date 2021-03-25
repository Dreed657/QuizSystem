using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.Common;
using Server.Models.Question;

namespace Server.Services.Questions
{
    public interface IQuestionService
    {
        Task<QuestionViewModel> GetById(int id);

        Task<IEnumerable<QuestionViewModel>> GetAllForExam(int examId);

        Task<bool> AddAnswer(AddAnswerToQuestion model);

        Task<QuestionViewModel> Create(CreateQuestionModel model);

        Task<QuestionViewModel> Update(UpdateQuestionModel model);

        Task<bool> Delete(int id);
    }
}
