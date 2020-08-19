using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class InstanceAddedToCachedWords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities");

            migrationBuilder.DropIndex(
                name: "IX_CachedWordEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities");

            migrationBuilder.DropColumn(
                name: "UserLogEntityUserLogId",
                table: "CachedWordEntities");

            migrationBuilder.AddColumn<int>(
                name: "CachedWordEntityCachedWordId",
                table: "UserLogEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLogEntities_CachedWordEntityCachedWordId",
                table: "UserLogEntities",
                column: "CachedWordEntityCachedWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                table: "UserLogEntities",
                column: "CachedWordEntityCachedWordId",
                principalTable: "CachedWordEntities",
                principalColumn: "CachedWordId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogEntities_CachedWordEntities_CachedWordEntityCachedWordId",
                table: "UserLogEntities");

            migrationBuilder.DropIndex(
                name: "IX_UserLogEntities_CachedWordEntityCachedWordId",
                table: "UserLogEntities");

            migrationBuilder.DropColumn(
                name: "CachedWordEntityCachedWordId",
                table: "UserLogEntities");

            migrationBuilder.AddColumn<int>(
                name: "UserLogEntityUserLogId",
                table: "CachedWordEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CachedWordEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities",
                column: "UserLogEntityUserLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityUserLogId",
                table: "CachedWordEntities",
                column: "UserLogEntityUserLogId",
                principalTable: "UserLogEntities",
                principalColumn: "UserLogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
