using ASZN.Services.Interface;
using ASZN.Web.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASZN.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] UserCreateDto dto, CancellationToken cancellationToken)
        {
            var userResult = await _userService.RegisterUserAsync(dto, cancellationToken);

            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto, CancellationToken cancellationToken)
        {
            var isValid = await _userService.ValidateUserAsync(dto, cancellationToken);
            if (!isValid)
            {
                return Unauthorized();
            }

            var token = await _userService.CreateTokenAsync(cancellationToken);
            return Ok(new UserLoginResponse() { Token = token});
        }
    }
}
