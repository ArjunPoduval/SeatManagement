using MainAssessment.Tables;
using Microsoft.EntityFrameworkCore;

namespace MainAssessment
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions options) : base(options) { }
        public DbSet<City> city { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Facility> facilities { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Seat> seat { get; set; }
        public DbSet<AssetType> assetType { get; set; }
        public DbSet<Cabin> cabin { get; set; }
        public DbSet<MeetingRoom> meetingRoom { get; set; }
        public DbSet<Assets> assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<UnAllocatedSeatsReport>()
                .ToView("UnAllocatedSeat")
                .HasKey(e => e.SeatId);
            modelBuilder
                .Entity<AllocatedSeatsReport>()
                .ToView("AllocatedSeat")
                .HasKey(e => e.SeatId);

        }


    }
}
