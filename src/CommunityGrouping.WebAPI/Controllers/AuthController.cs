using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CommunityGrouping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (userToLogin.Success)
            {
                return Ok(userToLogin);
            }
            return BadRequest(userToLogin);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = await _authService.Register(userForRegisterDto);
            if (registerResult.Success)
            {
                return Ok(registerResult);
            }
            return BadRequest(registerResult);
        }
    }
}
