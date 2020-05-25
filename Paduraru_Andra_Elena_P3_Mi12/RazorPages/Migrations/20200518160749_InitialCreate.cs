using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    Moved = table.Column<int>(nullable: false),
                    Evenimente = table.Column<string>(nullable: true),
                    Persoane = table.Column<string>(nullable: true),
                    Peisaje = table.Column<string>(nullable: true),
                    Locuri = table.Column<string>(nullable: true),
                    Altele = table.Column<string>(nullable: true),
                    DataCreare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaDTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaDTO");
        }
    }
}
