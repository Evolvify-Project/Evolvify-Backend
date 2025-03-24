﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.AppSettings
{
    public class SeedUsers
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class SeedUsersSettings
    {
        public List<SeedUsers> SeedUsers { get; set; }
    }

}
