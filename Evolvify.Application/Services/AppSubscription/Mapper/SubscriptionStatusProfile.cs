using AutoMapper;
using Evolvify.Application.Services.AppSubscription.DTOs;
using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.AppSubscription.Mapper
{
    public class SubscriptionStatusProfile:Profile
    {
        public SubscriptionStatusProfile()
        {
            CreateMap<Subscription, SubscriptionStatusDto>()
                .ForMember(dest => dest.Plan, opt => opt.MapFrom(src => src.PlanType.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Status == SubscriptionStatus.Active))
                .ForMember(dest => dest.Interval, opt => opt.MapFrom(src => src.Interval.HasValue ? src.Interval.ToString() : null))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.RemainingDays, opt => opt.MapFrom(src => (int) Math.Ceiling((src.EndDate - DateTime.UtcNow).TotalDays)));

                


        }
    }
}
