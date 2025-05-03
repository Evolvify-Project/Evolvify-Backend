using Evolvify.Application.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ProfileImage
{
    public class UploadProfilePictureCommand : IRequest<bool>
    {

        public string UserId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
