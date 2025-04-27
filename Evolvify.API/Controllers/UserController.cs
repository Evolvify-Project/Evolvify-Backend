using Evolvify.Application.Common.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //[HttpPost] 
        //public async Task<IActionResult> UploadPicture(ProfilePicture profilePicture )
        //{
        //    using var stream = new MemoryStream();
        //    await profilePicture.Image.CopyToAsync(stream);
        //    var image = new Image 
        //    {
        //        Id = profilePicture.Id
        //        ,image =  profilePicture
        //    };

        //    return Ok(image);
        //}   
    }
}
