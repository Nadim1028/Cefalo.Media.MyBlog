using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class nameConvertedToUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AuthorTable",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AuthorTable",
                newName: "Name");
        }
    }
}
