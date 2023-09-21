using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainAssessment.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetLookups",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLookups", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "CityLookups",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityLookups", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLookups",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLookups", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_CityLookups_CityId",
                        column: x => x.CityId,
                        principalTable: "CityLookups",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsAllocated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_DepartmentLookups_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentLookups",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilities_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinTable",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    CabinNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinTable", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_CabinTable_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_CabinTable_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoomTable",
                columns: table => new
                {
                    MeetingRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    MeetingRoomNumber = table.Column<int>(type: "int", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoomTable", x => x.MeetingRoomId);
                    table.ForeignKey(
                        name: "FK_MeetingRoomTable_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatTable",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTable", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_SeatTable_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_SeatTable_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    IndexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    MeetingRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.IndexId);
                    table.ForeignKey(
                        name: "FK_Assets_AssetLookups_AssetId",
                        column: x => x.AssetId,
                        principalTable: "AssetLookups",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_MeetingRoomTable_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "MeetingRoomTable",
                        principalColumn: "MeetingRoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetId",
                table: "Assets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_FacilityId",
                table: "Assets",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_MeetingRoomId",
                table: "Assets",
                column: "MeetingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CityId",
                table: "Buildings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinTable_EmployeeId",
                table: "CabinTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinTable_FacilityId",
                table: "CabinTable",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_BuildingId",
                table: "Facilities",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoomTable_FacilityId",
                table: "MeetingRoomTable",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTable_EmployeeId",
                table: "SeatTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTable_FacilityId",
                table: "SeatTable",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "CabinTable");

            migrationBuilder.DropTable(
                name: "SeatTable");

            migrationBuilder.DropTable(
                name: "AssetLookups");

            migrationBuilder.DropTable(
                name: "MeetingRoomTable");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "DepartmentLookups");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "CityLookups");
        }
    }
}
