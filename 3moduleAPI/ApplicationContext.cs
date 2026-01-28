using _3moduleAPI.Entity;
using _3moduleAPI.Interfaces.Services;
using _3moduleAPI.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI;

public class ApplicationContext : DbContext
{
    //public ApplicationContext()
    //{
    //    Database.EnsureCreated();
    //}

    public DbSet<UserEntity> User => Set<UserEntity>();
    public DbSet<RoomEntity> Room => Set<RoomEntity>();
    public DbSet<BlockEnity> Block => Set<BlockEnity>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db")
            .UseSeeding((context, _) =>
            {

                User.Add(UserEntity.Create("ivan", PasswordHashService.PasswordHashStatic("moredock1")));

                for (var i = 0; i < 3; i++) Room.Add(RoomEntity.Create(true));

                context.SaveChanges();
            });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<RoomEntity>(entity =>
        {
            entity.HasKey(room => room.Id);

            entity.HasMany(room => room.Blocks)
                .WithOne(block => block.Room)
                .HasForeignKey(block => block.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<BlockEnity>(entity =>
        {
            entity.HasKey(Block => Block.Id);

            //entity.HasOne(Block => Block.RoomId)
            //    .WithMany()
            //    .HasForeignKey(block => block.RoomId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //;


        });


        base.OnModelCreating(modelBuilder);
    }
}