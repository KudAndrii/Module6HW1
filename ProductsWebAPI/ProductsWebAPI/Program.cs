using Core.Entities;
using Core.Interfaces;
using Infrastructure.Configurations;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProductsWebAPI.Helpers;
using ProductsWebAPI.Models;

namespace ProductsWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();



            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<IAccountService<User, RegisterModel>, AccountService>();
            builder.Services.Configure<ProductsConfiguration>(builder.Configuration.GetSection("ProductsConfiguration"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}