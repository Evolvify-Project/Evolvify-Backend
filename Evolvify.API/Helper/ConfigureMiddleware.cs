using Evolvify.API.Middlewares;
using Evolvify.Domain.AppSettings;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Data.Seeding;
using Evolvify.Infrastructure.Data.Seeding.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Evolvify.API.Helper
{
    public static class ConfigureMiddleware
    {
        public static async Task< WebApplication> ConfigureMiddlewareAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context =  services.GetRequiredService<EvolvifyDbContext>();

            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await context.Database.MigrateAsync();
            }

           

            var Ioptions = services.GetRequiredService<IOptions<SeedUsersSettings>>();
            var configuration = services.GetRequiredService<IConfiguration>();

            await RoleSeeder.SeedRolesAsync(services, Ioptions);
            var seeder = services.GetRequiredService<ISeeder>();
            await seeder.SeedAsync();


            app.UseMiddleware<ExceptionMiddleware>();

            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();


            return app;
        }
       
     }    

}
