using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;
using System.Data;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AddRegisterRequestDto addRegisterRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = addRegisterRequestDto.UserName,
                Email = addRegisterRequestDto.UserName
            };

            var identityUserResult = await userManager.CreateAsync(identityUser, addRegisterRequestDto.Password);

            if (identityUserResult.Succeeded)
            {
                if (addRegisterRequestDto.Roles != null && addRegisterRequestDto.Roles.Any())
                {
                    identityUserResult = await userManager.AddToRolesAsync(identityUser, addRegisterRequestDto.Roles);

                    if (identityUserResult.Succeeded)
                    {
                        return Ok("Đăng ký tài khoản thành công. Vui lòng đăng nhập.");
                    }
                }
            }


            return BadRequest("Upss! Lỗi rồi.");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);

            if (user != null)
            {

                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginReponseDto { JwtToken = jwtToken };

                        return Ok(response);
                    }

                }
            }

            return BadRequest("Upss! Lỗi rồi.");
        }
    }
}
