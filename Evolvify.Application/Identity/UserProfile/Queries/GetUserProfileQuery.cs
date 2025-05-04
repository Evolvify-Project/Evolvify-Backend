using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Identity.UserProfile.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Queries
{
    public class GetUserProfileQuery:IRequest<ApiResponse<UserProfileDto>>
    {

    }
}
