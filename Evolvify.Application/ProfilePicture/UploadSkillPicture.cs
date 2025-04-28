using Evolvify.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.ProfilePicture
{
    public class UploadSkillPicture
    {
        public string Upload(IFormFile file)
        {
            List<string> ValidExtention = new List<string>() { ".jpg ", ".png", ".gif" };
            var extention = Path.GetExtension(file.FileName);
            if (!ValidExtention.Contains(extention))
            {
                return $"Extention is not valid ({string.Join(',', ValidExtention)})";
            }

            //long size = file.Length();
            //if (size > (5 * 1024 * 1024))
            //{
            //    return "Maximum size can be 5mb";
            //}

            string FileName = Guid.NewGuid().ToString() + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Upload");
            using FileStream stream = new FileStream(path + FileName, FileMode.Create);
            file.CopyTo(stream);

            return FileName;
        }


    }
}
