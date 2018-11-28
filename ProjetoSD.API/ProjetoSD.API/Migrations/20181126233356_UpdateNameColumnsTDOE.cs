using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class UpdateNameColumnsTDOE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CDOEPROFLAXIA",
                table: "TDOE",
                newName: "CDOEVITE");

            migrationBuilder.RenameColumn(
                name: "CDOENOME",
                table: "TDOE",
                newName: "CDOEOQEH");

            migrationBuilder.RenameColumn(
                name: "CDOEDESC",
                table: "TDOE",
                newName: "CDOETRATAMENTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CDOEVITE",
                table: "TDOE",
                newName: "CDOEPROFLAXIA");

            migrationBuilder.RenameColumn(
                name: "CDOEOQEH",
                table: "TDOE",
                newName: "CDOENOME");

            migrationBuilder.RenameColumn(
                name: "CDOETRATAMENTO",
                table: "TDOE",
                newName: "CDOEDESC");
        }
    }
}
