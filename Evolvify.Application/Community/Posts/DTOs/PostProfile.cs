using AutoMapper;
using Evolvify.Application.Community.Posts.Commands.UpdatePost;
using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.DTOs
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt,
                     opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss tt")))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                //.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Where(c => c.ParentCommentId == null)))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count))
                .ForMember(dest=>dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Where(c=>c.ParentCommentId==null).Count()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();


            CreateMap<UpdatePostCommand, Post>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
           

        }
    }
}
