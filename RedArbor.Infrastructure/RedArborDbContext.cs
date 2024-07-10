using Microsoft.EntityFrameworkCore;
using RedArbor.Domain.Entities;

namespace RedArbor.Infrastructure
{
    public class RedArborDbContext : DbContext
    {

        public RedArborDbContext(DbContextOptions<RedArborDbContext> options)
            : base(options)
        {
            InitalizeContext();
        }

        protected virtual void InitalizeContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //Database.SetCommandTimeout(360);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new MatriculaMap());
            //modelBuilder.ApplyConfiguration(new ProgramaAcademicoMap());
            //modelBuilder.ApplyConfiguration(new AspiranteMap());
            //modelBuilder.ApplyConfiguration(new StatusMap());
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Portal> Portal { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}