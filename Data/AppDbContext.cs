using Microsoft.EntityFrameworkCore;
using HeroCreator.Models;

namespace HeroCreator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Character>? Characters { get; set; }
    }
}
