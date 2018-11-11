using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class CreateTableMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMED",
                columns: table => new
                {
                    CMEDID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CMEDCRM = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    CMEDNOME = table.Column<string>(type: "VARCHAR(90)", nullable: false),
                    CMEDUF = table.Column<string>(nullable: false),
                    CMEDPROFISSAO = table.Column<string>(type: "VARCHAR(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMED", x => x.CMEDID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TMED_CMEDCRM",
                table: "TMED",
                column: "CMEDCRM",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMED");
        }
    }
}
