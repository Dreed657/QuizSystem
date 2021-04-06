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
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;

        public QuestionsController(IQuestionService questionService, IAnswerService answerService)
        {
            this.questionService = questionService;
            this.answerService = answerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.questionService.GetAll();

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await this.questionService.GetById(Id);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("Exam/{ExamId}")]
        public async Task<IActionResult> GetExamQuestions(int ExamId)
        {
            var result = await this.questionService.GetAllForExam(ExamId);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("Answers/{QuestionId}")]
        public async Task<IActionResult> GetQuestionAnswers(int questionId)
        {
            var result = await this.answerService.GetByQuestionId(questionId);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("AddAnswer")]
        public async Task<IActionResult> AddAnswer(AddAnswerToQuestion model)
        {
            var result = await this.questionService.AddAnswer(model);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.questionService.Create(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestionModel model)
        {
            var result = await this.questionService.Update(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.questionService.Delete(id);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
