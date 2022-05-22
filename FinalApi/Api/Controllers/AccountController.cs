using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Api.Helper.Helper;

namespace Api.Controllers
{
    public class AccountController : BaseController
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            AppUser user = new()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Surname = registerDto.Surname
            };

            await _userManager.CreateAsync(user, registerDto.Password);
            // await _userManager.AddToRoleAsync(user, "admin");
            return Ok();
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            return Ok();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null) return NotFound();

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);

            string token = _tokenService.GenerateJwtToken(user.UserName, (List<string>)roles);

            return Ok(token);
        }
    }
}
