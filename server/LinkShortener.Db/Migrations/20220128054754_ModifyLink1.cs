using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkShortener.Db.Migrations
{
    public partial class ModifyLink1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "datecreated",
                schema: "core",
                table: "links",
                newName: "date_created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "core",
                table: "links",
                newName: "datecreated");
        }
    }
}
