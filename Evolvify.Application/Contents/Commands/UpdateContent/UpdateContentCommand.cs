using Evolvify.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Commands.UpdateContent
{
    public class UpdateContentCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public ContentTypes ContentType { get; set; }
    }
}
