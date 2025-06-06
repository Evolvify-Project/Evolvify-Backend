
using Evolvify.API.Helper;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Data.Seeding;

namespace Evolvify.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDependency(builder.Configuration);
            var app = builder.Build();

            
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
                var context = scope.ServiceProvider.GetRequiredService<EvolvifyDbContext>();
                await seeder.SeedAsync(context, scope.ServiceProvider);
            }
            
           
            await app.ConfigureMiddlewareAsync();
            app.Run();
        }
    }
}
