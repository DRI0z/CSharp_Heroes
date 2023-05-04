using CSharp_Heroes.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Heroes.Context
{
    public class ApplicationDbContext : DbContext
    {
        private const string connectionString = "Data Source=PC-ENZO\\SQLEXPRESS;Initial Catalog=HeroDb;Integrated Security=True;Encrypt=False";
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.School)
                .WithMany(h => h.Heroes)
                .HasForeignKey(h => h.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HeroPower>().HasKey(hp => new { hp.HeroId, hp.PowerId });

            modelBuilder.Entity<HeroPower>()
                .HasOne<Hero>(hp => hp.Hero)
                .WithMany(h => h.Powers)
                .HasForeignKey(p => p.HeroId);

            modelBuilder.Entity<HeroPower>()
                .HasOne<Power>(hp => hp.Power)
                .WithMany(p => p.Heroes)
                .HasForeignKey(p => p.PowerId);



            base.OnModelCreating(modelBuilder);
        }

        DbSet<Hero> Heroes { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Power> Powers { get; set; }
        DbSet<HeroPower> HeroPowers{ get; set; }
    }
}
