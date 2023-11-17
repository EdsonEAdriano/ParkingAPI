using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingAPI.Migrations
{
    /// <inheritdoc />
    public partial class alterTableControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Controls",
                newName: "status");

            migrationBuilder.AddColumn<DateTime>(
                name: "exitDate",
                table: "Controls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exitDate",
                table: "Controls");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Controls",
                newName: "type");
        }
    }
}
