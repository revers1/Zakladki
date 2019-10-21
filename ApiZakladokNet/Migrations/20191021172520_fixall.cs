using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiZakladokNet.Migrations
{
    public partial class fixall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AddColumn<string>(
                name: "CoordX",
                table: "Product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoordY",
                table: "Product",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordX",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CoordY",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoordX = table.Column<string>(nullable: false),
                    CoordY = table.Column<string>(nullable: false),
                    Product_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_Id",
                table: "Order",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_Id",
                table: "Order",
                column: "User_Id");
        }
    }
}
