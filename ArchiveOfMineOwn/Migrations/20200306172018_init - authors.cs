using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchiveOfMineOwn.Migrations
{
    public partial class initauthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseud = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Bio = table.Column<string>(maxLength: 255, nullable: true),
                    NumWorks = table.Column<int>(nullable: false, defaultValue: 0),
                    NumBookmarks = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalHits = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalWordCount = table.Column<int>(nullable: false, defaultValue: 0),
                    Joined = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Pseud",
                table: "Authors",
                column: "Pseud",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
