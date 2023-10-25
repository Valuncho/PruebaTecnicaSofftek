using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Services;
using System.Reflection;

namespace PruebaTecnicaSofftek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<CurrencyInformationService>();
            // esto fue un problema
            builder.Services.AddControllers();

            // conexion a la base de datos
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("name=DefaultConnection");
            });
            builder.Services.AddAutoMapper(typeof(Mapping));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            //app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}