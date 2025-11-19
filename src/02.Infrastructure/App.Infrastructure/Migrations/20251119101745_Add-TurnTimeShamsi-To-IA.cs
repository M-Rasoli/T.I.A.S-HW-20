using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTurnTimeShamsiToIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TurnTimeShamsi",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnTimeShamsi",
                table: "Appointments");
        }
    }
}
