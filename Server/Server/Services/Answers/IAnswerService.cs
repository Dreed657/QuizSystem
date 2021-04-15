using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.Answer;

namespace Server.Services.Answers
{
    public interface IAnswerService
    {
        Task<AnswerViewModel> GetById(int id);

        Task<IEnumerable<AnswerViewModel>> GetByQuestionId(int id);

        Task<AnswerViewModel> Create(CreateAnswerModel model);

        Task<AnswerViewModel> Update(UpdateAnswerModel model);

        Task<bool> Delete(int id);

        Task<bool> SaveAnswer(string userId, SaveAnswerInputModel model);
    }
}
