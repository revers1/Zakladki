using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiZakladokNet.Migrations
{
    public partial class changecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_User_Id",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_User_Id",
                table: "Product",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_User_Id",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_User_Id",
                table: "Product",
                column: "User_Id",
                unique: true);
        }
    }
}
