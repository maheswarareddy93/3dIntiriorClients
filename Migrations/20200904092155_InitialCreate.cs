using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3dIntiriorClients.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerInfo",
                columns: table => new
                {
                    Customerid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customername = table.Column<string>(nullable: true),
                    Emailid = table.Column<string>(nullable: true),
                    Mobileno = table.Column<string>(nullable: true),
                    LeadType = table.Column<string>(nullable: true),
                    IsActive = table.Column<sbyte>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerInfo", x => x.Customerid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerInfo");
        }
    }
}
