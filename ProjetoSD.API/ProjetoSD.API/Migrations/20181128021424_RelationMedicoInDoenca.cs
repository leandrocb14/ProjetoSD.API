using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class RelationMedicoInDoenca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CDOEMEDICID",
                table: "TDOE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TDOE_CDOEMEDICID",
                table: "TDOE",
                column: "CDOEMEDICID");

            migrationBuilder.AddForeignKey(
                name: "FK_TDOE_TMED_CDOEMEDICID",
                table: "TDOE",
                column: "CDOEMEDICID",
                principalTable: "TMED",
                principalColumn: "CMEDID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDOE_TMED_CDOEMEDICID",
                table: "TDOE");

            migrationBuilder.DropIndex(
                name: "IX_TDOE_CDOEMEDICID",
                table: "TDOE");

            migrationBuilder.DropColumn(
                name: "CDOEMEDICID",
                table: "TDOE");
        }
    }
}
