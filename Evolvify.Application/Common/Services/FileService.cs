using Evolvify.Domain.Interfaces.ImageInterface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Common.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadImage(IFormFile image)
       {
            var imageName=$"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            var FolderPath=Path.Combine(_webHostEnvironment.WebRootPath,"Images","ProfileImage");

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var imagePath= Path.Combine(FolderPath, imageName);

            using var stream=File.Create(imagePath);
            await image.CopyToAsync(stream);

            return $"/Images/ProfileImage/{imageName}";

           

       }
    }
}
