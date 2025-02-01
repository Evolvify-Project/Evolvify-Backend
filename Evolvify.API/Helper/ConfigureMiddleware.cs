namespace Evolvify.API.Helper
{
    public static class ConfigureMiddleware
    {
        public static WebApplication ConfigureMiddlewareAsync(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            return app;
        }
       
     }    

}
