using KPCOS.Api.Extensions;
using KPCOS.Api.Middleware;
using KPCOS.Api.Service.Implement;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            // Add services to the container.
            builder.Services.AddService();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddDbContext<KpcosdbContext>(
                _ =>
                {
                    _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddConfigSwagger();

            builder.Services.AddCorsPolicy();

            // Register your services here
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}

