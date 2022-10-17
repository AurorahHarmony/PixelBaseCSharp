using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixelBase.Migrations
{
    public partial class AddAssetImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Asset",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Asset");
        }
    }
}
