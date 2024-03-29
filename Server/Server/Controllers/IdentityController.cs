﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Server.Data.Models;
using Server.Infrastructure.Helpers;
using Server.Models.Identity;
using Server.Services.Identity;

namespace Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService _identity;
        private readonly AppSettings _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityController(IIdentityService identity, IOptions<AppSettings> appSettings,
            UserManager<ApplicationUser> userManager)
        {
            this._identity = identity;
            this._appSettings = appSettings.Value;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return this.Unauthorized(new {message = "Invalid Credentials."});
            }

            var passwordValid = await this._userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return this.Unauthorized(new {message = "Invalid Credentials."});
            }

            var roles = await this._userManager.GetRolesAsync(user);

            var token = this._identity.GenerateJwtToken(
                user.Id,
                user.UserName,
                roles,
                this._appSettings.Secret);

            return this.Ok(new
            {
                token,
            });
        }

        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            var result = await this._userManager.CreateAsync(user, model.Password);
            await this._userManager.AddToRoleAsync(user, "Student");

            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            return this.Ok();
        }
    }
}