using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiZakladokNet.Migrations
{
    public partial class xz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ZakazClient",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZakazClient_UserId",
                table: "ZakazClient",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZakazClient_User_UserId",
                table: "ZakazClient",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZakazClient_User_UserId",
                table: "ZakazClient");

            migrationBuilder.DropIndex(
                name: "IX_ZakazClient_UserId",
                table: "ZakazClient");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ZakazClient");
        }
    }
}
