using Microsoft.EntityFrameworkCore.Migrations;

namespace WebIdentity.Data.Migrations
{
    public partial class ManagerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Problem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Problem");
        }
    }
}
