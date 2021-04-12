using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Answer;
using Server.Services.Answers;
using Server.Services.Common;

namespace Server.Controllers
{
    public class AnswersController : ApiController
    {
        private readonly IAnswerService answerService;
        private readonly ICurrentUserService user;

        public AnswersController(IAnswerService answerService, ICurrentUserService user)
        {
            this.answerService = answerService;
            this.user = user;
        }

        [HttpGet]
        public async Task<IActionResult> index(int Id)
        {
            var result = await this.answerService.GetById(Id);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnswerModel model)
        {
            var result = await this.answerService.Create(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnswerModel model)
        {
            var result = await this.answerService.Update(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.answerService.Delete(id);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(nameof(SaveAnswer))]
        public async Task<IActionResult> SaveAnswer(SaveAnswerInputModel model)
        {
            var userId = this.user.GetId();
            var result = await this.answerService.SaveAnswer(userId, model);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(model);
        }
    }
}
