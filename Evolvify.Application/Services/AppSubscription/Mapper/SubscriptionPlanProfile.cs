using AutoMapper;
using Evolvify.Application.Services.AppSubscription.DTOs;
using Evolvify.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.AppSubscription.Mapper
{
    public class SubscriptionPlanProfile:Profile
    {
        public SubscriptionPlanProfile()
        {
            CreateMap<SubscriptionPlan, SubscriptionPlanDto>()
                .ForMember(dest => dest.Interval, opt => opt.MapFrom(src => src.Interval.ToString()));
        }
    }
}
