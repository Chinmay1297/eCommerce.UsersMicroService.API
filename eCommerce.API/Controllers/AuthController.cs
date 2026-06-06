using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
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

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest, [FromServices] IValidator<RegisterRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(registerRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            //Check for invalid register Request
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }

            //Call the UserService to handle registration
            AuthenticationResponse? authenticationResponse = await _userService.Registration(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("login")] //Combination of [HttpPost] and [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest, [FromServices] IValidator<LoginRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(loginRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);

            if(authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
