using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class RelationUsuarioInMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CMEDUSUID",
                table: "TMED",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TMED_CMEDUSUID",
                table: "TMED",
                column: "CMEDUSUID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TMED_TUSU_CMEDUSUID",
                table: "TMED",
                column: "CMEDUSUID",
                principalTable: "TUSU",
                principalColumn: "CUSUID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMED_TUSU_CMEDUSUID",
                table: "TMED");

            migrationBuilder.DropIndex(
                name: "IX_TMED_CMEDUSUID",
                table: "TMED");

            migrationBuilder.DropColumn(
                name: "CMEDUSUID",
                table: "TMED");
        }
    }
}
