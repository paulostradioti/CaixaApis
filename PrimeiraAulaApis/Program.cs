
using Microsoft.EntityFrameworkCore;
using PrimeiraAulaApis.Logic.Repositories;
using PrimeiraAulaApis.Logic.Service;
using PrimeiraAulaApis.Middlewares;
using System.Reflection;

namespace PrimeiraAulaApis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Application Services
            builder.Services.AddScoped<ITodoService, TodoService>();
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbName = builder.Configuration.GetConnectionString("Default");
            var dbPath = Path.Combine(appData, dbName);
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"DataSource={dbPath}"));
            
            var app = builder.Build();
            
            app.UseMiddleware<TodoExceptionHandlerMiddleware>();

            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            dbContext.Database.EnsureCreated();
            
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            await app.RunAsync();
        }
    }
}
