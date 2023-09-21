using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainAssessment.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW UnAllocatedSeat AS 
                        SELECT S.SeatId,C.CityAbbreviation,B.BuildingAbbreviation,F.Floor,F.FacilityName,S.SeatNumber,
                        FROM Buildings B JOIN CityLookups C ON B.CityId=C.CityId
                        JOIN Facilities F ON B.BuildingId=F.BuildingId
                        JOIN SeatTable S ON F.FacilityId=S.FacilityId AND S.EmployeeId IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW UnAllocatedSeat");
        }
    }
}
