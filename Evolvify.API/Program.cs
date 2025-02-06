
using Evolvify.API.Helper;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Evolvify.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDependency(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);


            var app = builder.Build();
            app.ConfigureMiddlewareAsync();
            app.Run();
        }
    }
}
