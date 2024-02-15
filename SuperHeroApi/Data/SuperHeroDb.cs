using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;
using System.Diagnostics;

namespace SuperHeroApi.Data
{
    public class SuperHeroDb : DbContext
    {
        public SuperHeroDb(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>()
                .HasOne<Places>(p => p.HeroPlaces)
                .WithMany(s => s.SuperHeroes)
                .HasForeignKey(s => s.PlaceRefId);
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Places> Places { get; set; }
    }
}
