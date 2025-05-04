using AutoMapper;
using Evolvify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace Evolvify.Application.Identity.UserProfile.DTOs
{
    public class PictureUrlResolver : IValueResolver<ApplicationUser, UserProfileDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor to inject IHttpContextAccessor
        public PictureUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Resolve the ProfileImageUrl to a complete URL
        public string Resolve(ApplicationUser source, UserProfileDto destination, string destMember, ResolutionContext context)
        {
            // Check if ProfileImageUrl is null or empty
            if (string.IsNullOrEmpty(source.ProfileImageUrl))
            {
                return string.Empty; // Return empty string if no image
            }

            // Get current request to construct base URL
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}"; // Build base URL (http/https + domain)

            // Return the full URL to the image
            return $"{baseUrl}{source.ProfileImageUrl}";
        }
    }
}
