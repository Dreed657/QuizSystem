using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : ApiController
    {
        public UsersController()
        {
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("ASD");
        }
    }
}
