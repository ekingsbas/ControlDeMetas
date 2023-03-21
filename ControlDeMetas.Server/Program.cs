using ControlDeMetas.BLL.Contracts;
using ControlDeMetas.BLL.Services;
using ControlDeMetas.DAL;
using ControlDeMetas.DAL.Abstract;
using ControlDeMetas.DAL.Contracts;
using ControlDeMetas.DAL.Repositories;
using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControlDeMetas.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Agregando la dependencia hacia la capa de negocio

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MetasDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IRepository<Meta>, MetaRepository>();
            builder.Services.AddScoped<IRepository<Tarea>, TareaRepository>();

            builder.Services.AddScoped<IBaseService<Meta>, MetaService>();
            builder.Services.AddScoped<IBaseService<Tarea>, TareaService>();

            builder.Services.AddCors(policy =>
            {
                policy.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:5242")
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials());
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}