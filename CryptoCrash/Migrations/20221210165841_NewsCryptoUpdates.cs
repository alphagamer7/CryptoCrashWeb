using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCrash.Migrations
{
    public partial class NewsCryptoUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SrcData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrcData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CryptCurrency",
                columns: table => new
                {
                    Asset_id_quote = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Asset_id_base = table.Column<double>(type: "float", nullable: false),
                    Src_side_quoteId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptCurrency", x => x.Asset_id_quote);
                    table.ForeignKey(
                        name: "FK_CryptCurrency_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CryptCurrency_SrcData_Src_side_quoteId",
                        column: x => x.Src_side_quoteId,
                        principalTable: "SrcData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptCurrency_ApplicationUserId",
                table: "CryptCurrency",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptCurrency_Src_side_quoteId",
                table: "CryptCurrency",
                column: "Src_side_quoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptCurrency");

            migrationBuilder.DropTable(
                name: "SrcData");
        }
    }
}
