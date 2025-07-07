using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masrofy.DAL.Migrations
{
    public partial class ApplicationUserPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_SavingGoals_userId",
                table: "SavingGoals");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UserProfileId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_userId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_userId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "SavingGoals");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Plans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_IdentityUserId",
                table: "Plans",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AspNetUsers_IdentityUserId",
                table: "Plans",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AspNetUsers_IdentityUserId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_IdentityUserId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Plans");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "SavingGoals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingGoals_userId",
                table: "SavingGoals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserProfileId",
                table: "Plans",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userId",
                table: "Notifications",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_userId",
                table: "Expenses",
                column: "userId");

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
    }
}
