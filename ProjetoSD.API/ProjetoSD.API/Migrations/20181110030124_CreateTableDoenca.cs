using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSD.WebAPI.Migrations
{
    public partial class CreateTableDoenca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TDOE",
                columns: table => new
                {
                    CDOEID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CDOENOME = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    CDOEDESC = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    CDOEPROFLAXIA = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    CDOETIPOSTATUS = table.Column<string>(nullable: false, defaultValue: "S")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDOE", x => x.CDOEID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDOE");
        }
    }
}
