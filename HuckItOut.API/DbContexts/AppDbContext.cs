using HuckItOut.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HuckItOut.API.DbContexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Player> Players { get; set; } = null!;


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;password=123456789;user=root;database=hack_it_out",
                new MySqlServerVersion(new Version(8, 0, 40)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(player =>
            {

                player.HasKey(p => p.Id);

                player
                .Property(p => p.FirstName)
                .HasMaxLength(64);

                player
                .Property(p => p.LastName)
                .HasMaxLength(64);

                player
                .Property(p => p.SecondName)
                .HasMaxLength(64);

                player
                .Property(p => p.PhoneNumber)
                .HasMaxLength(11);
            });
        }

    }
}
