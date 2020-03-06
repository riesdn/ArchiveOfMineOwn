using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchiveOfMineOwn.Migrations
{
    public partial class worksadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false, defaultValue: "Untitled"),
                    AuthorId = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(maxLength: 255, nullable: true),
                    WordCount = table.Column<int>(nullable: false, defaultValue: 0),
                    Hits = table.Column<int>(nullable: false, defaultValue: 0),
                    Chapters = table.Column<int>(nullable: false, defaultValue: 1),
                    TotalChapters = table.Column<int>(nullable: true),
                    NumComments = table.Column<int>(nullable: false, defaultValue: 0),
                    NumKudos = table.Column<int>(nullable: false, defaultValue: 0),
                    NumBookmarks = table.Column<int>(nullable: false, defaultValue: 0),
                    Published = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    Updated = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_AuthorId",
                table: "Works",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
