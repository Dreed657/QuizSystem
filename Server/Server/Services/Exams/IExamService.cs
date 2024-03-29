﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.Common;
using Server.Models.Exam;

namespace Server.Services.Exams
{
    public interface IExamService
    {
        Task<IEnumerable<ShortExamModel>> GetAll();

        Task<ExamViewModel> GetById(int id);

        Task<bool> AddQuestion(AddQuestionInputModel model);
        
        Task<bool> RemoveQuestion(RemoveQuestionInputModel model);

        Task<ExamViewModel> Create(CreateExamModel model);

        Task<ExamViewModel> Update(UpdateExamModel model);

        Task<bool> Delete(int examId);
        
        Task<StartExamModel> Start(string userId, int examId);

        Task<FinishExamModel> Finish(string userId, int examId);
    }
}
