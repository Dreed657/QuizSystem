using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Common;
using Server.Models.Exam;
using Server.Services.Common;
using Server.Services.Exams;

namespace Server.Controllers
{
    public class ExamsController : ApiController
    {
        private readonly IExamService _examService;
        private readonly ICurrentUserService _user;

        public ExamsController(IExamService examService, ICurrentUserService user)
        {
            this._examService = examService;
            this._user = user;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await this._examService.GetById(Id);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._examService.GetAll();
            
            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamModel model)
        {
            var result = await this._examService.Create(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateExamModel model)
        {
            var result = await this._examService.Update(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await this._examService.Delete(Id);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        

        [HttpPost(nameof(AddQuestion))]
        public async Task<IActionResult> AddQuestion(AddQuestionInputModel model)
        {
            var result = await this._examService.AddQuestion(model);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut(nameof(RemoveQuestion))]
        public async Task<IActionResult> RemoveQuestion(RemoveQuestionInputModel model)
        {
            var result = await this._examService.RemoveQuestion(model);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(nameof(Start))]
        public async Task<IActionResult> Start(int examId)
        {
            var userId = this._user.GetId();
            var result = await this._examService.Start(userId, examId);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(nameof(Finish))]
        public async Task<IActionResult> Finish(int examId)
        {
            var userId = this._user.GetId();
            var result = await this._examService.Finish(userId, examId);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
