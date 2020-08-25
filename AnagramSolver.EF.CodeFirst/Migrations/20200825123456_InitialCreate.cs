using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CachedWordEntities",
                columns: table => new
                {
                    CachedWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachedWordEntities", x => x.CachedWordId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogEntities",
                columns: table => new
                {
                    UserLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CachedWordEntityCachedWordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogEntities", x => x.UserLogId);
                    table.ForeignKey(
                        name: "FK_UserLogEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                        column: x => x.CachedWordEntityCachedWordId,
                        principalTable: "CachedWordEntities",
                        principalColumn: "CachedWordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WordEntities",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CachedWordEntityCachedWordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordEntities", x => x.WordId);
                    table.ForeignKey(
                        name: "FK_WordEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                        column: x => x.CachedWordEntityCachedWordId,
                        principalTable: "CachedWordEntities",
                        principalColumn: "CachedWordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogEntities_CachedWordEntityCachedWordId",
                table: "UserLogEntities",
                column: "CachedWordEntityCachedWordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities",
                column: "CachedWordEntityCachedWordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogEntities");

            migrationBuilder.DropTable(
                name: "WordEntities");

            migrationBuilder.DropTable(
                name: "CachedWordEntities");
        }
    }
}
