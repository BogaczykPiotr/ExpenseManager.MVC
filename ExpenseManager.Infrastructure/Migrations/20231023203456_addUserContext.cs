using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Transfers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Stats",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDisplayedActions",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Settings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "SavingGoals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CreatedById",
                table: "Transfers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_CreatedById",
                table: "Stats",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CreatedById",
                table: "Settings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SavingGoals_CreatedById",
                table: "SavingGoals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedById",
                table: "Categories",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingGoals_AspNetUsers_CreatedById",
                table: "SavingGoals",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AspNetUsers_CreatedById",
                table: "Settings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_AspNetUsers_CreatedById",
                table: "Stats",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_CreatedById",
                table: "Transfers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingGoals_AspNetUsers_CreatedById",
                table: "SavingGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AspNetUsers_CreatedById",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_AspNetUsers_CreatedById",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_CreatedById",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_CreatedById",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Stats_CreatedById",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Settings_CreatedById",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_SavingGoals_CreatedById",
                table: "SavingGoals");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SavingGoals");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDisplayedActions",
                table: "Settings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
