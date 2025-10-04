using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asset_Management_Sciforn.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AssetCondition> AssetCondition { get; set; }
        public DbSet<AssetStatus> AssetStatus { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<AssetAssigned> AssetAssigned { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed AssetCondition
            builder.Entity<AssetCondition>().HasData(
                new AssetCondition { Id = 1, ConditionName = "New" },
                new AssetCondition { Id = 2, ConditionName = "Good" },
                new AssetCondition { Id = 3, ConditionName = "Needs Repair" },
                new AssetCondition { Id = 4, ConditionName = "Damaged" }
            );

            // Seed AssetStatus
            builder.Entity<AssetStatus>().HasData(
                new AssetStatus { Id = 1, StatusName = "Available" },
                new AssetStatus { Id = 2, StatusName = "Assigned" },
                new AssetStatus { Id = 3, StatusName = "Under Repair" },
                new AssetStatus { Id = 4, StatusName = "Retired" }
            );
        }
    }
}

// Errors ->
// Different Namespace issue because of the different project names, copied and this one
