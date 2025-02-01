using Evolvify.Application.Identity.Login;
using Evolvify.Application.Identity.Register;
using MediatR;
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
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "One or more errors occurred",
                Detail = response.Message,
                Extensions = { { "errors", response.Errors } }

            });


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "One or more errors occurred",
                Detail = response.Message,
                Extensions = { { "errors", response.Errors } }

            });
          


        }
    }
}
