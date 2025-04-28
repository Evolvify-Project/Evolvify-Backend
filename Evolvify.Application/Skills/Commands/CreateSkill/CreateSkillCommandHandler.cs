using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, ApiResponse<SkillDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        public CreateSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper , IWebHostEnvironment env)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
        }

        public async Task<ApiResponse<SkillDto>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {

            //string imagePath = null;

            //if (request.SkillImage != null && request.SkillImage.Length > 0)
            //{
            //    var uploadsFolder = Path.Combine(env.WebRootPath, "uploads/skills");
            //    if (!Directory.Exists(uploadsFolder))
            //    {
            //        Directory.CreateDirectory(uploadsFolder);
            //    }

            //    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.SkillImage.FileName);
            //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await request.SkillImage.CopyToAsync(fileStream);
            //    }

                
            //    imagePath = Path.Combine("uploads/skills", uniqueFileName).Replace("\\", "/");
            //}


            var skill = new Skill
            {
                Name = request.Name,
                Description = request.Description
            };
           
           await unitOfWork.Repository<Skill,int>().CreateAsync(skill);
           await unitOfWork.CompleteAsync();

           return new ApiResponse<SkillDto>(mapper.Map<SkillDto>(skill));
   
        }
    }
}
