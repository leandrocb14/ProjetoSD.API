using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class CreateTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TUSU",
                columns: table => new
                {
                    CUSUID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CUSUEMAIL = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    CUSUSENHA = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    CUSUTIPOSTATUS = table.Column<string>(nullable: false, defaultValue: "S")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUSU", x => x.CUSUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TUSU");
        }
    }
}
