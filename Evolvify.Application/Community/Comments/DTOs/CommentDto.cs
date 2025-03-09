﻿using Evolvify.Application.Community.Replies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string PostId { get; set; } = string.Empty;
        public int LikesCount { get; set; }
        public int RepliesCount { get; set; }
        public ICollection<ReplyDto> Replies { get; set; } = new List<ReplyDto>();

    }
}
