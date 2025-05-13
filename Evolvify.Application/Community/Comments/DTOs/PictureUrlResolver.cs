using AutoMapper;
using Evolvify.Application.Community.Comments.DTOs;

using Evolvify.Application.Community.Posts.DTOs;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Community;
using Microsoft.AspNetCore.Http;

using System;

namespace Evolvify.Application.Community.Comments.DTOs
{
    public class PictureUrlResolver : IValueResolver<Comment, CommentDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor to inject IHttpContextAccessor
        public PictureUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Resolve the ProfileImageUrl to a complete URL
        public string Resolve(Comment source, CommentDto destination, string destMember, ResolutionContext context)
        {
            


            // Check if ProfileImageUrl is null or empty
            if (string.IsNullOrEmpty(source?.User?.ProfileImageUrl??string.Empty))
            {
                return string.Empty; // Return empty string if no image
            }

            // Get current request to construct base URL
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}"; // Build base URL (http/https + domain)

            // Return the full URL to the image
            return $"{baseUrl}{source.User.ProfileImageUrl}";
        }
    }
}
