using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyPlannerV6.Data.Migrations
{
    /// <inheritdoc />
    public partial class Vigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
