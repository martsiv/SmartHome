using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueMacAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueSensorValue",
                table: "Sensors");

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "Sensors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Sensors_MacAddress",
                table: "Sensors",
                column: "MacAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Sensors_MacAddress",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "Sensors");

            migrationBuilder.AddColumn<string>(
                name: "UniqueSensorValue",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
