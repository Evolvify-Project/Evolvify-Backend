using AutoMapper;
using Evolvify.Application.Identity.UserProfile.DTOs;
using Evolvify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace Evolvify.Application.Identity.UserProfile.Mapping
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            // CreateMap to map ApplicationUser (IdentityUser) to UserProfileDto
            CreateMap<ApplicationUser, UserProfileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                // Mapping ProfileImageUrl
                .ForMember(dest => dest.ProfileImageUrl,
                           opt => opt.MapFrom<PictureUrlResolver<UserProfileDto>>());

            CreateMap<ApplicationUser, UserProfileImageDto>()
                .ForMember(dest => dest.ImageUrl,
                           opt => opt.MapFrom<PictureUrlResolver<UserProfileImageDto>>());
        }

    }
}