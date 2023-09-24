using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainAssessment.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW UnAllocatedSeats AS 
                        SELECT S.SeatId,C.CityAbbreviation,B.BuildingAbbreviation,F.Floor,F.FacilityName,S.SeatNumber
                        FROM Buildings B JOIN city C ON B.CityId=C.CityId
                        JOIN Facilities F ON B.BuildingId=F.BuildingId
                        JOIN seat S ON F.FacilityId=S.FacilityId AND S.EmployeeId IS NULL;");
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW AllocatedSeat AS 
                        SELECT S.SeatId,C.CityAbbreviation,B.BuildingAbbreviation,F.Floor,F.FacilityName,S.SeatNumber,E.EmployeeId,E.EmployeeName
                        FROM Buildings B JOIN city C ON B.CityId=C.CityId
                        JOIN Facilities F ON B.BuildingId=F.BuildingId
                        JOIN seat S ON F.FacilityId=S.FacilityId AND S.EmployeeId IS NOT NULL
						JOIN Employees E ON S.EmployeeId=E.EmployeeId;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW UnAllocatedSeat");
            migrationBuilder.Sql(@"DROP VIEW AllocatedSeat");
        }
    }
}
