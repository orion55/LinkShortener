using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkShortener.Db.Migrations
{
    public partial class ModifyLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "links",
                newSchema: "core");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "core",
                table: "links",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "To",
                schema: "core",
                table: "links",
                newName: "to");

            migrationBuilder.RenameColumn(
                name: "From",
                schema: "core",
                table: "links",
                newName: "from");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                schema: "core",
                table: "links",
                newName: "datecreated");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "core",
                table: "links",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Clicks",
                schema: "core",
                table: "links",
                newName: "clicks");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "core",
                table: "links",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_links",
                schema: "core",
                table: "links",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_links",
                schema: "core",
                table: "links");

            migrationBuilder.RenameTable(
                name: "links",
                schema: "core",
                newName: "Links");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Links",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "to",
                table: "Links",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "from",
                table: "Links",
                newName: "From");

            migrationBuilder.RenameColumn(
                name: "datecreated",
                table: "Links",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Links",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "clicks",
                table: "Links",
                newName: "Clicks");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Links",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");
        }
    }
}
