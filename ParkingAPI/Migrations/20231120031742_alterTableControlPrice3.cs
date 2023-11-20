using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingAPI.Migrations
{
    /// <inheritdoc />
    public partial class alterTableControlPrice3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controls_Prices_priceID",
                table: "Controls");

            migrationBuilder.AlterColumn<short>(
                name: "priceID",
                table: "Controls",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddForeignKey(
                name: "FK_Controls_Prices_priceID",
                table: "Controls",
                column: "priceID",
                principalTable: "Prices",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controls_Prices_priceID",
                table: "Controls");

            migrationBuilder.AlterColumn<short>(
                name: "priceID",
                table: "Controls",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Controls_Prices_priceID",
                table: "Controls",
                column: "priceID",
                principalTable: "Prices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
