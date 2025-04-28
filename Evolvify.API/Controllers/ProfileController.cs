using Evolvify.Application.Common.User;
using Evolvify.Application.ProfilePicture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        [HttpPost] 
        public IActionResult UploadImage(IFormFile file)
        {
            return Ok(new UploadPicture());

        }

       

    }
}
