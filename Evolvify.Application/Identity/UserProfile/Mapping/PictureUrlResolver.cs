using AutoMapper;
using Evolvify.Application.Identity.UserProfile.DTOs;
using Evolvify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace Evolvify.Application.Identity.UserProfile.Mapping
{
    public class PictureUrlResolver<TDestination> : IValueResolver<ApplicationUser, TDestination, string?>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor to inject IHttpContextAccessor
        public PictureUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Resolve the ProfileImageUrl to a complete URL
        public string Resolve(ApplicationUser source, TDestination destination, string destMember, ResolutionContext context)
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
