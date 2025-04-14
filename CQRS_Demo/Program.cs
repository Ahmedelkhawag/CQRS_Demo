
using CQRS_Library;
using CQRS_Library.Data;
using CQRS_Library.Repos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS")));
            builder.Services.AddScoped<IItemsRepository, ItemRepsitory>();
            builder.Services.AddMediatR(typeof(MyLibrary).Assembly);

            //builder.Services.AddMediatR(typeof(MyLibrary).Assembly);
            // builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
