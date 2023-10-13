using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyPlannerV6.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderClassNameEventName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Orders",
                newName: "EventName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Orders",
                newName: "EventId");
        }
    }
}
