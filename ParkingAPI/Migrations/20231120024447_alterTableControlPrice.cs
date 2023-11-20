using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingAPI.Migrations
{
    /// <inheritdoc />
    public partial class alterTableControlPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Controls");

            migrationBuilder.AddColumn<short>(
                name: "priceID",
                table: "Controls",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Controls_priceID",
                table: "Controls",
                column: "priceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Controls_Prices_priceID",
                table: "Controls",
                column: "priceID",
                principalTable: "Prices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controls_Prices_priceID",
                table: "Controls");

            migrationBuilder.DropIndex(
                name: "IX_Controls_priceID",
                table: "Controls");

            migrationBuilder.DropColumn(
                name: "priceID",
                table: "Controls");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Controls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
