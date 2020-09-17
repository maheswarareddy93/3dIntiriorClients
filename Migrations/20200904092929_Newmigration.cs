using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3dIntiriorClients.Migrations
{
    public partial class Newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    IsActive = table.Column<sbyte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDataInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Projectname = table.Column<string>(nullable: true),
                    UnitType = table.Column<string>(nullable: true),
                    UnitSize = table.Column<string>(nullable: true),
                    Referenceimages = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Finalimage = table.Column<string>(nullable: true),
                    cuuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDataInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminsInfo");

            migrationBuilder.DropTable(
                name: "ProjectDataInfo");

            migrationBuilder.DropTable(
                name: "PropertyTypes");
        }
    }
}
