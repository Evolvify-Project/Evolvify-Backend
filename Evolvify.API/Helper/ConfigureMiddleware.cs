using Evolvify.API.Middlewares;
using Evolvify.Infrastructure.Data.Seeding;

namespace Evolvify.API.Helper
{
    public static class ConfigureMiddleware
    {
        public static async Task< WebApplication> ConfigureMiddlewareAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            var seeder = services.GetRequiredService<ISeeder>();
            await seeder.SeedAsync();


            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // ✅ مهم يكون قبل UseAuthorization
            app.UseAuthorization();

            app.MapControllers();


            return app;
        }
       
     }    

}
