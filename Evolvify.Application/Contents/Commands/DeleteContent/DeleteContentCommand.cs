using Evolvify.Application.Contents.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
