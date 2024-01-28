using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_AspNetUsers_CreatedById",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_CreatedById",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Achievements");

            migrationBuilder.AddColumn<int>(
                name: "TransfersCount",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransfersCount",
                table: "Transfers");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Achievements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_CreatedById",
                table: "Achievements",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_AspNetUsers_CreatedById",
                table: "Achievements",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
