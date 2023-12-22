using AutoMapper;
using Ensolvers_Application.Interface;
using Ensolvers_Application.Service;
using Ensolvers_Infrastructure.DataContext;
using Ensolvers_Infrastructure.Interface;
using Ensolvers_Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ensolvers_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Configuration
            builder.Configuration.AddJsonFile("appsettings.json");

            // DbContext configuration

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<EnsolversDbContext>(options => options.UseSqlServer(connectionString));

            ConfigureServices(builder.Services, builder.Configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddAutoMapper(typeof(Mapper));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EnsolversDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}