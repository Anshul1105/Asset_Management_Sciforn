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

            // Seed Employees
            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Alice Johnson", Department = "IT", Email = "alice.johnson@example.com", PhoneNumber = "9876543210", Designation = "Software Engineer", IsActive = true },
                new Employee { Id = 2, FullName = "Bob Smith", Department = "Finance", Email = "bob.smith@example.com", PhoneNumber = "9876543211", Designation = "Accountant", IsActive = true },
                new Employee { Id = 3, FullName = "Carol Davis", Department = "HR", Email = "carol.davis@example.com", PhoneNumber = "9876543212", Designation = "HR Manager", IsActive = true },
                new Employee { Id = 4, FullName = "David Brown", Department = "IT", Email = "david.brown@example.com", PhoneNumber = "9876543213", Designation = "System Administrator", IsActive = true },
                new Employee { Id = 5, FullName = "Eva Wilson", Department = "Operations", Email = "eva.wilson@example.com", PhoneNumber = "9876543214", Designation = "Operations Manager", IsActive = true }
            );
            builder.Entity<Asset>().HasData(
    new Asset { Id = 1, Name = "Dell Latitude Laptop", AssetType = "Laptop", MakeModel = "Latitude 7420", SerialNumber = "DL7420X123", PurchaseDate = new DateTime(2023, 1, 15), WarrantyExpiryDate = new DateTime(2026, 1, 14), AssetConditionId = 1, AssetStatusId = 1, IsSpare = false, Specifications = "Intel i7, 16GB RAM, 512GB SSD" },
    new Asset { Id = 2, Name = "HP ProDesk Desktop", AssetType = "Desktop", MakeModel = "ProDesk 400 G7", SerialNumber = "HP400G7X456", PurchaseDate = new DateTime(2022, 6, 10), WarrantyExpiryDate = new DateTime(2025, 6, 9), AssetConditionId = 2, AssetStatusId = 2, IsSpare = false, Specifications = "Intel i5, 8GB RAM, 1TB HDD" },
    new Asset { Id = 3, Name = "Epson Projector", AssetType = "Projector", MakeModel = "EB-X41", SerialNumber = "EPX41Y789", PurchaseDate = new DateTime(2021, 11, 20), WarrantyExpiryDate = new DateTime(2024, 11, 19), AssetConditionId = 3, AssetStatusId = 3, IsSpare = false, Specifications = "XGA, 3600 Lumens" },
    new Asset { Id = 4, Name = "Cisco Router", AssetType = "Networking", MakeModel = "RV340", SerialNumber = "CISR340Z101", PurchaseDate = new DateTime(2020, 8, 5), WarrantyExpiryDate = new DateTime(2023, 8, 4), AssetConditionId = 4, AssetStatusId = 4, IsSpare = false, Specifications = "Dual WAN, Gigabit Ethernet" },
    new Asset { Id = 5, Name = "Logitech Mouse", AssetType = "Peripheral", MakeModel = "MX Master 3", SerialNumber = "LOGMX30012", PurchaseDate = new DateTime(2023, 2, 1), WarrantyExpiryDate = new DateTime(2025, 2, 1), AssetConditionId = 1, AssetStatusId = 1, IsSpare = true, Specifications = "Wireless, Rechargeable" },
    new Asset { Id = 6, Name = "Apple MacBook Pro", AssetType = "Laptop", MakeModel = "MacBook Pro 14", SerialNumber = "MBP14X999", PurchaseDate = new DateTime(2024, 3, 12), WarrantyExpiryDate = new DateTime(2027, 3, 11), AssetConditionId = 1, AssetStatusId = 2, IsSpare = false, Specifications = "M2 Pro, 16GB RAM, 1TB SSD" },
    new Asset { Id = 7, Name = "Samsung Monitor", AssetType = "Monitor", MakeModel = "S24R350", SerialNumber = "SAMON24123", PurchaseDate = new DateTime(2022, 12, 5), WarrantyExpiryDate = new DateTime(2025, 12, 4), AssetConditionId = 2, AssetStatusId = 1, IsSpare = true, Specifications = "24-inch, Full HD, LED" },
    new Asset { Id = 8, Name = "HP LaserJet Printer", AssetType = "Printer", MakeModel = "MFP M227fdw", SerialNumber = "HP227X321", PurchaseDate = new DateTime(2021, 5, 20), WarrantyExpiryDate = new DateTime(2024, 5, 19), AssetConditionId = 3, AssetStatusId = 3, IsSpare = false, Specifications = "Laser, Duplex, Wireless" },
    new Asset { Id = 9, Name = "Lenovo ThinkPad Laptop", AssetType = "Laptop", MakeModel = "ThinkPad X1", SerialNumber = "LTPX11234", PurchaseDate = new DateTime(2020, 9, 1), WarrantyExpiryDate = new DateTime(2023, 8, 31), AssetConditionId = 4, AssetStatusId = 4, IsSpare = false, Specifications = "Intel i7, 16GB RAM, 512GB SSD" },
    new Asset { Id = 10, Name = "Apple iPad", AssetType = "Tablet", MakeModel = "iPad Air 5", SerialNumber = "IPAD5X678", PurchaseDate = new DateTime(2023, 7, 10), WarrantyExpiryDate = new DateTime(2026, 7, 9), AssetConditionId = 1, AssetStatusId = 2, IsSpare = false, Specifications = "10.9-inch, 256GB, Wi-Fi" },
    new Asset { Id = 11, Name = "Dell Docking Station", AssetType = "Accessory", MakeModel = "WD19", SerialNumber = "DELD19X890", PurchaseDate = new DateTime(2023, 2, 14), WarrantyExpiryDate = new DateTime(2025, 2, 13), AssetConditionId = 2, AssetStatusId = 1, IsSpare = true, Specifications = "USB-C, Multiple Ports" }
);

        }
    }
}
