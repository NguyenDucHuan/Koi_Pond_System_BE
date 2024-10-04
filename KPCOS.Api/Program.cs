using KPCOS.Api.Extensions;
using KPCOS.Api.Middleware;
using KPCOS.Api.Service.Implement;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;

namespace KPCOS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký logging
            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Cấu hình logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            // Thêm các provider khác nếu cần
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(opts
                    => opts.SuppressModelStateInvalidFilter = true);
            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            // Add services to the container.
            builder.Services.AddService();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionMiddleware();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddDbContext<KpcosdbContext>(
                _ =>
                {
                    _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddConfigSwagger();

            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Add CORS middleware here, before routing and authorization
            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();


            app.UseAuthentication();
            app.UseAuthorization(); //<< This needs to be between app.UseRouting(); and app.UseEndpoints();
            app.MapControllers();

            app.Run();
        }
    }
}

