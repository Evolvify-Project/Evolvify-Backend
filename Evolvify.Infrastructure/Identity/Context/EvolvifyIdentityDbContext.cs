using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Identity.Context
{
    public class EvolvifyIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public EvolvifyIdentityDbContext(DbContextOptions<EvolvifyIdentityDbContext> options) : base(options)
        {

        }
    }
}
