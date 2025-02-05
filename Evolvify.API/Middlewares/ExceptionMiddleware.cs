
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Exceptions;

namespace Evolvify.API.Middlewares
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) :IMiddleware
    {
      
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFound)
            {
                context.Response.StatusCode=StatusCodes.Status404NotFound;

                var response = new ApiResponse<string>(
                    success: false,
                    statusCode: StatusCodes.Status404NotFound,
                    message: notFound.Message
                );

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new ApiResponse<string>(
                    success: false,
                    statusCode: StatusCodes.Status500InternalServerError,
                    message: ex.Message
                    
                );

               await context.Response.WriteAsJsonAsync(response);
                
               
            }
        }
    }
}
