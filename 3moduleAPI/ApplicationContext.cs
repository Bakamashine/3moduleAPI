using _3moduleAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public ApplicationContext() => Database.EnsureCreated();
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
