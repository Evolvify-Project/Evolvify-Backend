using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using Evolvify.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.Skills
{
    public static class ModuleSeeder
    {
        public static List<Module> GetModules()
        {
           var typesData = File.ReadAllText(@"..\Evolvify.Infrastructure\Data\Seeding\DataSeed\Modules.json");

            // Deserialize the JSON data into a list of Module objects
            var modules = JsonSerializer.Deserialize<List<Module>>(typesData);

            if (modules == null || !modules.Any())
            {
                throw new NotFoundException("Modules not found");
            }
            return modules;
        }
    }
}