using Microsoft.EntityFrameworkCore;
using HeroCreator.Models;

namespace HeroCreator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Character>? Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(c => c.Id)
                      .HasColumnType("uuid")
                      .HasColumnName("id");

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasColumnName("name"); 

                entity.Property(c => c.Class)
                      .IsRequired()
                      .HasColumnName("class"); 

                entity.Property(c => c.Inventory)
                      .IsRequired()
                      .HasColumnName("inventory");

                entity.Property(c => c.Attributes)
                      .IsRequired()
                      .HasColumnName("attributes");

                entity.Property(c => c.Level)
                      .IsRequired()
                      .HasColumnName("level");
                      
            });

            modelBuilder.Entity<Character>().ToTable("characters");
        }
    }
}

