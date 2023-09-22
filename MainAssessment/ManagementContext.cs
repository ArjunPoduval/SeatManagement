using MainAssessment.Tables;
using Microsoft.EntityFrameworkCore;

namespace MainAssessment
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions options) : base(options) { }
        public DbSet<City> CityLookups { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Department> DepartmentLookups { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Seat> SeatTable { get; set; }
        public DbSet<AssetType> AssetLookups { get; set; }
        public DbSet<Cabin> CabinTable { get; set; }
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
