using AutoMapper;
using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.DTOs
{
    public class ContentProfile:Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentDto>();
        }
    }
}
