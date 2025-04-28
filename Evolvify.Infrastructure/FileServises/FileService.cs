using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.FileServises
{
    public class FileService : IFileService
    {
        private readonly EvolvifyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;


        public FileService(EvolvifyDbContext context,IWebHostEnvironment webHostEnvironment , IFileService fileService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        public async Task<string> UploadImage(string Location, IFormFile file)
        {
            var path = _webHostEnvironment.ContentRootPath + "/" + Location + "/";
            var extention = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty)+ extention;


            if (file.Length > 1) 
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return $"{path}+ {fileName}";
                    }
                }
                catch (Exception ) 
                {
                    return "Failed";
                }

                
            }
            else
            {
                return "NoImage";
            }

        }



        public async Task<string> AddSkillImage(Skill skill, IFormFile file)
        {
            var imageUrl = await _fileService.UploadImage("Skill", file);
            switch(imageUrl)
            {
                case "NoImage": return "NoImage";
                case "Failed": return "Failed";
            }
            skill.SkillImage = imageUrl;
            try
            {
                await _context.AddAsync(skill);
                return "Success";
            }
            catch (Exception) 
            {
                return "FailedInAdd";
            }
        }

    }
}
