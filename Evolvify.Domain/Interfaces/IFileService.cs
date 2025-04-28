using Evolvify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);

        public Task<string> AddSkillImage(Skill skill, IFormFile file);
    }

    
}
