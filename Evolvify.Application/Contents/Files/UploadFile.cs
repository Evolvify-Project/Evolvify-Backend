using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Files
{
    public class UploadFile
    {
        public IFormFile? File { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } =string.Empty;

    }
}
