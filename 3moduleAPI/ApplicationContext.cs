using _3moduleAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<UserEntity> User => Set<UserEntity>();
    public DbSet<RoomEntity> Room => Set<RoomEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}