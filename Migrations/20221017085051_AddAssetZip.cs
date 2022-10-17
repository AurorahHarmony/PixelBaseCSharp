using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixelBase.Migrations
{
    public partial class AddAssetZip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZipName",
                table: "Asset",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipName",
                table: "Asset");
        }
    }
}
