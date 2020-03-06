using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchiveOfMineOwn.Migrations
{
    public partial class worktitlefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Works",
                maxLength: 100,
                nullable: false,
                defaultValue: "Untitled",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Untitled");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Works",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Untitled",
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldDefaultValue: "Untitled");
        }
    }
}
