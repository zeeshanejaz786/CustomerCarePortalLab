using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCarePortalLab.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_OrganizationID",
                table: "Department",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Organization_OrganizationID",
                table: "Department",
                column: "OrganizationID",
                principalTable: "Organization",
                principalColumn: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Organization_OrganizationID",
                table: "Department");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Department_OrganizationID",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Department");
        }
    }
}
