using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evolvify.API.Middlewares
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFound)
            {
                await HandleExceptionAsync(context, StatusCodes.Status404NotFound, notFound.Message);
            }
            catch (AssessmentAlreadyCompletedException assessmentAlreadyCompleted)
            {
                await HandleExceptionAsync(context, StatusCodes.Status200OK, assessmentAlreadyCompleted.Message);
            }
            catch (UnauthorizedAccessException unauthorized)
            {
                await HandleExceptionAsync(context, StatusCodes.Status401Unauthorized, unauthorized.Message);
            }
           
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<string>(
                success: false,
                statusCode: statusCode,
                message: message
            );

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
