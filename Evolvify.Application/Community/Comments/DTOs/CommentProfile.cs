using AutoMapper;
using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.DTOs
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment,CommentDto>()
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.Replies, opt => opt.MapFrom(src => src.Replies))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count))
                .ForMember(dest => dest.RepliesCount, opt => opt.MapFrom(src => src.Replies.Count))
                .ReverseMap();
                
        }
    }
}
