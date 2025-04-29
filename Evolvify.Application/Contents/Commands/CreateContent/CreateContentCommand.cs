using Evolvify.Application.Contents.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommand : IRequest<ApiResponse<ContentDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public ContentTypes ContentType { get; set; }
    }
}
