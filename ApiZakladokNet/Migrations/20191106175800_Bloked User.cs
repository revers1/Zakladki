using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiZakladokNet.Migrations
{
    public partial class BlokedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bloked_Id",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblUser_Is_Bloked",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_User = table.Column<int>(nullable: false),
                    Bloked = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Is_Bloked", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUser_Is_Bloked_User_Id_User",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Bloked_Id",
                table: "User",
                column: "Bloked_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_Is_Bloked_Id_User",
                table: "tblUser_Is_Bloked",
                column: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_tblUser_Is_Bloked_Bloked_Id",
                table: "User",
                column: "Bloked_Id",
                principalTable: "tblUser_Is_Bloked",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_tblUser_Is_Bloked_Bloked_Id",
                table: "User");

            migrationBuilder.DropTable(
                name: "tblUser_Is_Bloked");

            migrationBuilder.DropIndex(
                name: "IX_User_Bloked_Id",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Bloked_Id",
                table: "User");
        }
    }
}
