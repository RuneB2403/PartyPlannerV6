﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyPlannerV6.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventClassNameEventName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "EventName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "Name");
        }
    }
}
