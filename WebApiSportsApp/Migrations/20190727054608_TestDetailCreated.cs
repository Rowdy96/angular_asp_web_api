using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiSportsApp.Migrations
{
    public partial class TestDetailCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestDetail",
                columns: table => new
                {
                    AthleteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AthleteName = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    Distance = table.Column<decimal>(nullable: false),
                    MyProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDetail", x => x.AthleteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestDetail");
        }
    }
}
