using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Profile;

namespace Server.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProfile(string id)
        {
            var result = await this._profileService.GetProfile(id);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
