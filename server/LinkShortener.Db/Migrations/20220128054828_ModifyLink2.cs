using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkShortener.Db.Migrations
{
    public partial class ModifyLink2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "core",
                table: "links",
                newName: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "core",
                table: "links",
                newName: "userid");
        }
    }
}
