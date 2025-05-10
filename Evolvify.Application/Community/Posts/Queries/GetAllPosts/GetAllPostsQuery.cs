using Evolvify.Application.Common.Response;
using Evolvify.Application.Community.Posts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQuery: IRequest<PaginationResponse<IEnumerable<PostDto>>>
    {
        public int PageNumber { get; set; }=1;
        public int PageSize { get; set; } = 10;
    }
}
