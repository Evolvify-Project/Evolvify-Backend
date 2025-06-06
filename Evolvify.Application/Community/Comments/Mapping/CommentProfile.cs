﻿using AutoMapper;
using Evolvify.Application.Common;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.Community.Replies.DTOs;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count))
                .ForMember(dest => dest.RepliesCount, opt => opt.MapFrom(src => src.Replies.Count))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom<PictureUrlResolver>());


            CreateMap<Comment, ReplyDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.ParentCommentId, opt => opt.MapFrom(src => src.ParentCommentId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count))
                .ForMember(dest => dest.Replys, opt => opt.MapFrom(src => src.Replies))
                .ForMember(dest => dest.RepliesCount, opt => opt.MapFrom(src => src.Replies.Count))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom<Replies.DTOs.PictureUrlResolver>());


        }
    }
}
