using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces.ImageInterface
{
    public interface IFileService
    {
        Task<string> UploadImage(IFormFile image);
        void DeleteImage(string imageUrl);
    }
}
