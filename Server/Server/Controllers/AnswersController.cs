using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Answer;
using Server.Services.Answers;
using Server.Services.Common;

namespace Server.Controllers
{
    public class AnswersController : ApiController
    {
        private readonly IAnswerService _answerService;
        private readonly ICurrentUserService _user;

        public AnswersController(IAnswerService answerService, ICurrentUserService user)
        {
            this._answerService = answerService;
            this._user = user;
        }

        [HttpGet]
        public async Task<IActionResult> index(int Id)
        {
            var result = await this._answerService.GetById(Id);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnswerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this._answerService.Create(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnswerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this._answerService.Update(model);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this._answerService.Delete(id);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(nameof(SaveAnswer))]
        public async Task<IActionResult> SaveAnswer(SaveAnswerInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = this._user.GetId();
            var result = await this._answerService.SaveAnswer(userId, model);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(model);
        }
    }
}
