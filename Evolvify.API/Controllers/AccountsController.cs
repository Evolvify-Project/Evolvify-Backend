using Evolvify.Application.Identity.ConfirmEmail;
using Evolvify.Application.Identity.ForgetPassword;
using Evolvify.Application.Identity.Login;
using Evolvify.Application.Identity.Register;
using Evolvify.Application.Identity.ResetPassword;
using Evolvify.Application.Identity.UserProfile.Commands.UpdateUser;
using Evolvify.Application.Identity.UserProfile.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

      
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand command)
        {
            var response = await mediator.Send(command);
            //return response.Success ? Ok(response) : BadRequest(response);
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var response = await mediator.Send(new GetUserProfileQuery());
            return Ok(response);
        }

      

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserCommand command)
        {
             await mediator.Send(command);
            return NoContent();
        }



    }
}
