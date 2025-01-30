﻿using Evolvify.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Evolvify.Domain.Entities.Module;

namespace Evolvify.Infrastructure.Data.Context
{
    public class EvolvifyDbContext:IdentityDbContext<ApplicationUser>
    {
        public EvolvifyDbContext(DbContextOptions<EvolvifyDbContext> options):base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Content> Contents { get; set; }
    }
}
