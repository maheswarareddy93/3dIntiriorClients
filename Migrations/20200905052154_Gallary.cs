using Microsoft.EntityFrameworkCore.Migrations;

namespace _3dIntiriorClients.Migrations
{
    public partial class Gallary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "customerInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "customerInfo");
        }
    }
}
