using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CachingWebApi.Migrations
{
    public partial class correctColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriveNumber",
                table: "Drivers",
                newName: "DriverNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverNumber",
                table: "Drivers",
                newName: "DriveNumber");
        }
    }
}
