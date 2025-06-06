using Evolvify.Infrastructure.Data.Context;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(EvolvifyDbContext context, IServiceProvider services);
        Task SeedAsync();
    }
}
