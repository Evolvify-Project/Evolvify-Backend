using AutoMapper;
using Evolvify.Application.Contents.DTOs;
using Evolvify.Application.Courses.Commands.CreateCourse;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, ApiResponse<ContentDto>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;

        public CreateContentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.environment = environment;
        }

        public async Task<ApiResponse<ContentDto>> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            
            var content = new Content
            {
                Title = request.Title,
                Text = request.Text,
                Url = request.Url,

            };

            await unitOfWork.Repository<Content, int>().CreateAsync(content);
            await unitOfWork.CompleteAsync();

            return new ApiResponse<ContentDto>(mapper.Map<ContentDto>(content));
        }


    }
}
