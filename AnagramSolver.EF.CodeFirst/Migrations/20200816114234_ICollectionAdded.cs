using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class ICollectionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CachedWordEntityID",
                table: "WordEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLogEntityID",
                table: "CachedWordEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordEntities_CachedWordEntityID",
                table: "WordEntities",
                column: "CachedWordEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_CachedWordEntities_UserLogEntityID",
                table: "CachedWordEntities",
                column: "UserLogEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityID",
                table: "CachedWordEntities",
                column: "UserLogEntityID",
                principalTable: "UserLogEntities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityID",
                table: "WordEntities",
                column: "CachedWordEntityID",
                principalTable: "CachedWordEntities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityID",
                table: "CachedWordEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityID",
                table: "WordEntities");

            migrationBuilder.DropIndex(
                name: "IX_WordEntities_CachedWordEntityID",
                table: "WordEntities");

            migrationBuilder.DropIndex(
                name: "IX_CachedWordEntities_UserLogEntityID",
                table: "CachedWordEntities");

            migrationBuilder.DropColumn(
                name: "CachedWordEntityID",
                table: "WordEntities");

            migrationBuilder.DropColumn(
                name: "UserLogEntityID",
                table: "CachedWordEntities");
        }
    }
}
