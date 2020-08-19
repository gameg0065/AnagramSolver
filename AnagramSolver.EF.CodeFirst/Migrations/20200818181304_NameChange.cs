using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CachedWordEntityCachedWordId",
                table: "WordEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities",
                column: "CachedWordEntityCachedWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities",
                column: "CachedWordEntityCachedWordId",
                principalTable: "CachedWordEntities",
                principalColumn: "CachedWordId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities");

            migrationBuilder.DropIndex(
                name: "IX_WordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities");

            migrationBuilder.DropColumn(
                name: "CachedWordEntityCachedWordId",
                table: "WordEntities");
        }
    }
}
