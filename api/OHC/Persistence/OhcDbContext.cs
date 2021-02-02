using Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Survey;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class OhcDbContext : DbContext, IOhcDbContext
    {
        public OhcDbContext(DbContextOptions<OhcDbContext> options)
            : base(options)
        {
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<FactorPosition> FactorPositions { get; set; }
        public DbSet<Survey> Surveys { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OhcDbContext).Assembly);

            modelBuilder.Entity<FactorPosition>()
                .HasKey(fp => new { fp.PositionId, fp.FactorId });

            modelBuilder.Entity<FactorPosition>()
                .HasOne(fp => fp.Factor)
                .WithMany(f => f.FactorPositions)
                .HasForeignKey(fp => fp.FactorId);

            modelBuilder.Entity<FactorPosition>()
                .HasOne(fp => fp.Position)
                .WithMany(p => p.FactorPositions)
                .HasForeignKey(fp => fp.PositionId);
        }
    }
}
