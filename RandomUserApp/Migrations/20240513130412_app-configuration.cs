using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RandomUserApp.Migrations
{
    public partial class appconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APPConfiguration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseAddress = table.Column<string>(type: "text", nullable: false),
                    ApiURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPConfiguration", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "APPConfiguration",
                columns: new[] { "ID", "ApiURL", "BaseAddress" },
                values: new object[] { 1, "https://randomuser.me/api/", "https://api.randomuser.me" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPConfiguration");
        }
    }
}
