using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiZakladokNet.Migrations
{
    public partial class thirdx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZakazClient_User_UserId",
                table: "ZakazClient");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ZakazClient",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ZakazClient_User_UserId",
                table: "ZakazClient",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZakazClient_User_UserId",
                table: "ZakazClient");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ZakazClient",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ZakazClient_User_UserId",
                table: "ZakazClient",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
