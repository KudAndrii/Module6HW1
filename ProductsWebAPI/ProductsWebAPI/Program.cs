using Infrastructure.Configurations;
using Infrastructure.Interfaces;
using Infrastructure.Services;

namespace ProductsWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // реализация IHost

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.Configure<ProductsConfiguration>(builder.Configuration.GetSection("ProductsConfiguration"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer(); // определение api
            builder.Services.AddSwaggerGen();

            var app = builder.Build(); // генерация хоста, который запускается как приложение

            // Configure the HTTP request pipeline. все что ниже - middlewhare
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}