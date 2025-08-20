
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PrimeiraAulaApis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbName = builder.Configuration.GetConnectionString("Default");
            var dbPath = Path.Combine(appData, dbName);
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"DataSource={dbPath}"));

            
            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            dbContext.Database.EnsureCreated();

            
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.Run();
        }
    }
}
