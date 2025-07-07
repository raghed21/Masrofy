using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masrofy.DAL.Migrations
{
    public partial class Migrationnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "Plans",
                newName: "Income");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Income",
                table: "Plans",
                newName: "MonthlyIncome");
        }
    }
}
