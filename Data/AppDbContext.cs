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
                      .HasColumnName("id"); // Nome em minúsculas.

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasColumnName("name"); // Nome em minúsculas.

                entity.Property(c => c.Class)
                      .IsRequired()
                      .HasColumnName("class"); // Nome em minúsculas.

                entity.Property(c => c.Inventory)
                      .IsRequired()
                      .HasColumnName("inventory"); // Nome em minúsculas.

                entity.Property(c => c.Attributes)
                      .IsRequired()
                      .HasColumnName("attributes"); // Nome em minúsculas.

                entity.Property(c => c.Level)
                      .IsRequired()
                      .HasColumnName("level") // Nome em minúsculas.
                      .HasDefaultValue(1); // Valor padrão.
            });

            // Se quiser, pode definir o nome da tabela em minúsculas também.
            modelBuilder.Entity<Character>().ToTable("characters");
        }
    }
}

