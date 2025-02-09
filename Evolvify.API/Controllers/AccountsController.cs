﻿using Evolvify.Application.Identity.ConfirmEmail;
using Evolvify.Application.Identity.ForgetPassword;
using Evolvify.Application.Identity.Login;
using Evolvify.Application.Identity.Register;
using Evolvify.Application.Identity.ResetPassword;
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
            return BadRequest(response);
        }

        [HttpPost("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromBody]ConfirmEmailCommand command)
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
    }
}
