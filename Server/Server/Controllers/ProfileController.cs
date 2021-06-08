using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Common;
using Server.Services.Profile;

namespace Server.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IProfileService _profileService;
        private readonly ICurrentUserService _currentUser;

        public ProfileController(IProfileService profileService, ICurrentUserService currentUser)
        {
            _profileService = profileService;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = this._currentUser.GetId();
            var result = await this._profileService.GetProfile(userId);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }


        [HttpGet(nameof(GetProfileByUserId))]
        public async Task<IActionResult> GetProfileByUserId([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Id query parameter is required!");
            }

            var result = await this._profileService.GetProfile(id);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }
    }
}