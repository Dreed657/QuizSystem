using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Server.Models.Common;
using Server.Models.Exam;
using Server.Services.Exams;

namespace Server.Controllers
{
    public class ExamsController : ApiController
    {
        private readonly IExamService examService;

        public ExamsController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpPost("Join")]
        public async Task<IActionResult> Join(string entryCode)
        {
            var result = await this.examService.GetByEntryCode(entryCode);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> index()
        {
            var result = await this.examService.GetAll();

            return Ok(result);
        }

        [HttpPost("AddQuestion")]
        public async Task<IActionResult> AddQuestion(AddQuestionInputModel model)
        {
            var result = await this.examService.AddQuestion(model);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamModel model)
        {
            var result = await this.examService.Create(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateExamModel model)
        {
            var result = await this.examService.Update(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await this.examService.Delete(Id);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
