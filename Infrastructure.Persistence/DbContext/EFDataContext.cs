using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sample.Domain;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.DbContext
{
    public class EFDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(
            options)
        {
        }

        public EFDataContext(string connectionString)
            : this(new DbContextOptionsBuilder<EFDataContext>()
                .UseSqlServer(connectionString).Options)
        {
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.LazyLoadingEnabled = false;
                tracker.AutoDetectChangesEnabled = true;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                return tracker;
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext)
                .Assembly);
        }
    }
}