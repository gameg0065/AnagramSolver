using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class AddNewIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityId",
                table: "CachedWordEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityId",
                table: "WordEntities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WordEntities",
                newName: "WordId");

            migrationBuilder.RenameColumn(
                name: "CachedWordEntityId",
                table: "WordEntities",
                newName: "CachedWordEntityCachedWordId");

            migrationBuilder.RenameIndex(
                name: "IX_WordEntities_CachedWordEntityId",
                table: "WordEntities",
                newName: "IX_WordEntities_CachedWordEntityCachedWordId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLogEntities",
                newName: "UserLogId");

            migrationBuilder.RenameColumn(
                name: "UserLogEntityId",
                table: "CachedWordEntities",
                newName: "UserLogEntityUserLogId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CachedWordEntities",
                newName: "CachedWordId");

            migrationBuilder.RenameIndex(
                name: "IX_CachedWordEntities_UserLogEntityId",
                table: "CachedWordEntities",
                newName: "IX_CachedWordEntities_UserLogEntityUserLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities",
                column: "UserLogEntityUserLogId",
                principalTable: "UserLogEntities",
                principalColumn: "UserLogId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities");

            migrationBuilder.RenameColumn(
                name: "WordId",
                table: "WordEntities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CachedWordEntityCachedWordId",
                table: "WordEntities",
                newName: "CachedWordEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_WordEntities_CachedWordEntityCachedWordId",
                table: "WordEntities",
                newName: "IX_WordEntities_CachedWordEntityId");

            migrationBuilder.RenameColumn(
                name: "UserLogId",
                table: "UserLogEntities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserLogEntityUserLogId",
                table: "CachedWordEntities",
                newName: "UserLogEntityId");

            migrationBuilder.RenameColumn(
                name: "CachedWordId",
                table: "CachedWordEntities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CachedWordEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities",
                newName: "IX_CachedWordEntities_UserLogEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityId",
                table: "CachedWordEntities",
                column: "UserLogEntityId",
                principalTable: "UserLogEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityId",
                table: "WordEntities",
                column: "CachedWordEntityId",
                principalTable: "CachedWordEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
