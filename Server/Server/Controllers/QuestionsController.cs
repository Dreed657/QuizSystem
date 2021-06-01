using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Common;
using Server.Models.Question;
using Server.Services.Answers;
using Server.Services.Questions;

namespace Server.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public QuestionsController(IQuestionService questionService, IAnswerService answerService)
        {
            this._questionService = questionService;
            this._answerService = answerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._questionService.GetAll();

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpGet("addable/{examId}")]
        public async Task<IActionResult> GetAllAddable(int examId)
        {
            var result = await this._questionService.GetAllAddable(examId);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await this._questionService.GetById(Id);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpGet("Exam/{ExamId}")]
        public async Task<IActionResult> GetExamQuestions(int ExamId)
        {
            var result = await this._questionService.GetAllForExam(ExamId);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpGet("Answers/{QuestionId}")]
        public async Task<IActionResult> GetQuestionAnswers(int questionId)
        {
            var result = await this._answerService.GetByQuestionId(questionId);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var result = await this._questionService.Create(model);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var result = await this._questionService.Update(model);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this._questionService.Delete(id);

            if (!result)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }
    }
}
