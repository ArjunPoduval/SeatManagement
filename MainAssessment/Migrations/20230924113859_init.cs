using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainAssessment.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assetType",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assetType", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "buildings",
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
                    table.PrimaryKey("PK_buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_buildings_city_CityId",
                        column: x => x.CityId,
                        principalTable: "city",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
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
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employees_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facilities",
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
                    table.PrimaryKey("PK_facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_facilities_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cabin",
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
                    table.PrimaryKey("PK_cabin", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_cabin_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_cabin_facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetingRoom",
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
                    table.PrimaryKey("PK_meetingRoom", x => x.MeetingRoomId);
                    table.ForeignKey(
                        name: "FK_meetingRoom_facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seat",
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
                    table.PrimaryKey("PK_seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_seat_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_seat_facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assets",
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
                    table.PrimaryKey("PK_assets", x => x.IndexId);
                    table.ForeignKey(
                        name: "FK_assets_assetType_AssetId",
                        column: x => x.AssetId,
                        principalTable: "assetType",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assets_facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assets_meetingRoom_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "meetingRoom",
                        principalColumn: "MeetingRoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_assets_AssetId",
                table: "assets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_assets_FacilityId",
                table: "assets",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_assets_MeetingRoomId",
                table: "assets",
                column: "MeetingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_CityId",
                table: "buildings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_cabin_EmployeeId",
                table: "cabin",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_cabin_FacilityId",
                table: "cabin",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_DepartmentId",
                table: "employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_facilities_BuildingId",
                table: "facilities",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_meetingRoom_FacilityId",
                table: "meetingRoom",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_seat_EmployeeId",
                table: "seat",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_seat_FacilityId",
                table: "seat",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assets");

            migrationBuilder.DropTable(
                name: "cabin");

            migrationBuilder.DropTable(
                name: "seat");

            migrationBuilder.DropTable(
                name: "assetType");

            migrationBuilder.DropTable(
                name: "meetingRoom");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
