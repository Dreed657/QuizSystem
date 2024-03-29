﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services.NewFolder;

namespace Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._userService.GetAll();

            if (!result.Any())
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await this._userService.GetById(id);

            if (result == null)
            {
                return this.BadRequest(result);
            }

            return this.Ok(result);
        }
    }
}
