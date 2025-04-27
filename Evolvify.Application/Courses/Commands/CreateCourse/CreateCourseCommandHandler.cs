using AutoMapper;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.Commands.CreateSkill;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ApiResponse<CourseDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment; 

        public CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.environment = environment;
        }

        public async Task<ApiResponse<CourseDto>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            string imagePath = null;

            if (request.ImageUrl != null && request.ImageUrl.Length > 0)
            {
                var uploadsFolder = Path.Combine(environment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.ImageUrl.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ImageUrl.CopyToAsync(stream);
                }

                imagePath = $"images/{fileName}";
            }

            var course = new Course
            {
                Title = request.Title,
                ImageUrl = imagePath,
                Description = request.Description,  
                CreatedAt = DateTime.UtcNow,
               
            };

            await unitOfWork.Repository<Course, int>().CreateAsync(course);
            await unitOfWork.CompleteAsync();

            return new ApiResponse<CourseDto>(mapper.Map<CourseDto>(course));
        }
    }

}
