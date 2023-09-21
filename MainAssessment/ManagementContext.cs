using MainAssessment.Tables;
using Microsoft.EntityFrameworkCore;

namespace MainAssessment
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions options) : base(options) { }
        public DbSet<CityLookup> CityLookups { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Department> DepartmentLookups { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SeatTable> SeatTable { get; set; }
        public DbSet<AssetLookup> AssetLookups { get; set; }
        public DbSet<CabinTable> CabinTable { get; set; }
        public DbSet<MeetingRoomTable> MeetingRoomTable { get; set; }
        public DbSet<Assets> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<UnAllocatedSeat>()
                .ToView("UnAllocatedSeat")
                .HasKey(e => e.SeatId);
            modelBuilder
                .Entity<AllocatedSeat>()
                .ToView("AllocatedSeat")
                .HasKey(e => e.SeatId);

        }


    }
}
