using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masrofy.DAL.Migrations
{
    public partial class UserProfileMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_User_userId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_User_userId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_User_userId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingGoals_User_userId",
                table: "SavingGoals");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Plans",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_userId",
                table: "Plans",
                newName: "IX_Plans_UserProfileId");

            migrationBuilder.AlterColumn<double>(
                name: "AmountSaved",
                table: "SavingGoals",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserProfiles_userId",
                table: "Expenses",
                column: "userId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_UserProfiles_userId",
                table: "Notifications",
                column: "userId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserProfiles_UserProfileId",
                table: "Plans",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingGoals_UserProfiles_userId",
                table: "SavingGoals",
                column: "userId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserProfiles_userId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_UserProfiles_userId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserProfiles_UserProfileId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingGoals_UserProfiles_userId",
                table: "SavingGoals");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Plans",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_UserProfileId",
                table: "Plans",
                newName: "IX_Plans_userId");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountSaved",
                table: "SavingGoals",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_User_userId",
                table: "Expenses",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_User_userId",
                table: "Notifications",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_User_userId",
                table: "Plans",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingGoals_User_userId",
                table: "SavingGoals",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
