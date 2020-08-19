using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class AddValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CachedWordEntities_UserLogEntities_UserLogEntityID",
                table: "CachedWordEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_WordEntities_CachedWordEntities_CachedWordEntityID",
                table: "WordEntities");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "WordEntities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CachedWordEntityID",
                table: "WordEntities",
                newName: "CachedWordEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_WordEntities_CachedWordEntityID",
                table: "WordEntities",
                newName: "IX_WordEntities_CachedWordEntityId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserLogEntities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserLogEntityID",
                table: "CachedWordEntities",
                newName: "UserLogEntityId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CachedWordEntities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CachedWordEntities_UserLogEntityID",
                table: "CachedWordEntities",
                newName: "IX_CachedWordEntities_UserLogEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "SearchWord",
                table: "CachedWordEntities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CachedWordEntityId",
                table: "WordEntities",
                newName: "CachedWordEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_WordEntities_CachedWordEntityId",
                table: "WordEntities",
                newName: "IX_WordEntities_CachedWordEntityID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLogEntities",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserLogEntityId",
                table: "CachedWordEntities",
                newName: "UserLogEntityID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CachedWordEntities",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CachedWordEntities_UserLogEntityId",
                table: "CachedWordEntities",
                newName: "IX_CachedWordEntities_UserLogEntityID");

            migrationBuilder.AlterColumn<string>(
                name: "SearchWord",
                table: "CachedWordEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
