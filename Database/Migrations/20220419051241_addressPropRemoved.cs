using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class addressPropRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addresss",
                table: "AuthorTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Addresss",
                table: "AuthorTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
