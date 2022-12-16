using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCrash.Migrations
{
    public partial class CryptoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CryptCurrency_SrcData_Src_side_quoteId",
                table: "CryptCurrency");

            migrationBuilder.DropTable(
                name: "SrcData");

            migrationBuilder.DropIndex(
                name: "IX_CryptCurrency_Src_side_quoteId",
                table: "CryptCurrency");

            migrationBuilder.RenameColumn(
                name: "Src_side_quoteId",
                table: "CryptCurrency",
                newName: "type_is_crypto");

            migrationBuilder.RenameColumn(
                name: "Asset_id_base",
                table: "CryptCurrency",
                newName: "price_usd");

            migrationBuilder.RenameColumn(
                name: "Asset_id_quote",
                table: "CryptCurrency",
                newName: "asset_id");

            migrationBuilder.AddColumn<string>(
                name: "id_icon",
                table: "CryptCurrency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "CryptCurrency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_icon",
                table: "CryptCurrency");

            migrationBuilder.DropColumn(
                name: "name",
                table: "CryptCurrency");

            migrationBuilder.RenameColumn(
                name: "type_is_crypto",
                table: "CryptCurrency",
                newName: "Src_side_quoteId");

            migrationBuilder.RenameColumn(
                name: "price_usd",
                table: "CryptCurrency",
                newName: "Asset_id_base");

            migrationBuilder.RenameColumn(
                name: "asset_id",
                table: "CryptCurrency",
                newName: "Asset_id_quote");

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

            migrationBuilder.CreateIndex(
                name: "IX_CryptCurrency_Src_side_quoteId",
                table: "CryptCurrency",
                column: "Src_side_quoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CryptCurrency_SrcData_Src_side_quoteId",
                table: "CryptCurrency",
                column: "Src_side_quoteId",
                principalTable: "SrcData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
