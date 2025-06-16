

namespace Evolvify.API.Controllers;

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

    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("GetUserProfileImage")]
    public async Task<IActionResult> GetUserProfileImage()
    {
        var response = await mediator.Send(new GetUserProfileImageQuery());
        return Ok(response);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("UpdateProfileImage")]
    public async Task<IActionResult> UpdateProfileImage([FromForm] UpdateProfileImageCommand command)
    {
        var result= await mediator.Send(command);
        return Ok(result);
    }

    
}
