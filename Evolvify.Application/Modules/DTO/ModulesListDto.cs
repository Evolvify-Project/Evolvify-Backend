using Evolvify.Application.Contents.DTOs;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.DTO
{
    public class ModulesListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
