using Microsoft.EntityFrameworkCore;

namespace PrimeiraAulaApis
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
