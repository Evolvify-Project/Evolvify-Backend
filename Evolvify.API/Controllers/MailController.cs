using Evolvify.Application.Email.EmailServices;
using Evolvify.Application.Email.EmailSettings;
using MailKit;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly IEmailService emailService;
    public MailController(IEmailService emailService)
    {
        this.emailService = emailService;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm] MailRequest request)
    {
        try
        {
            await emailService.SendEmail(request);
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}