using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class variableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Authors_AuthorId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "StoryTable");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "AuthorTable");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_AuthorId",
                table: "StoryTable",
                newName: "IX_StoryTable_AuthorId");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "AuthorTable",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoryTable",
                table: "StoryTable",
                column: "StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorTable",
                table: "AuthorTable",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryTable_AuthorTable_AuthorId",
                table: "StoryTable",
                column: "AuthorId",
                principalTable: "AuthorTable",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryTable_AuthorTable_AuthorId",
                table: "StoryTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoryTable",
                table: "StoryTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorTable",
                table: "AuthorTable");

            migrationBuilder.RenameTable(
                name: "StoryTable",
                newName: "Stories");

            migrationBuilder.RenameTable(
                name: "AuthorTable",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_StoryTable_AuthorId",
                table: "Stories",
                newName: "IX_Stories_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "AuthorName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Authors_AuthorId",
                table: "Stories",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
