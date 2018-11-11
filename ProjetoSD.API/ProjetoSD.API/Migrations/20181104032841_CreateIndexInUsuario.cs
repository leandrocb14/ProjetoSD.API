using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class CreateIndexInUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TUSU_CUSUEMAIL",
                table: "TUSU",
                column: "CUSUEMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TUSU_CUSUEMAIL",
                table: "TUSU");
        }
    }
}
