using ControlDeMetas.BLL.Contracts;
using ControlDeMetas.BLL.Services;
using ControlDeMetas.Shared.Entities;

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
            builder.Services.AddScoped<IBaseService<Meta>, MetaService>();
            builder.Services.AddScoped<IBaseService<Tarea>, TareaService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}