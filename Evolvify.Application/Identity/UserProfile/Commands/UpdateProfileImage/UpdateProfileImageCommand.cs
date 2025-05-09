using Evolvify.Application.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Commands.UpdateProfileImage;

public class UpdateProfileImageCommand : IRequest<ApiResponse<string>>
{
    public IFormFile Image { get; set; } 
}

