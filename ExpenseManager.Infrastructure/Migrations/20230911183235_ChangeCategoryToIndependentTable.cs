using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryToIndependentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Category",
                table: "Transfers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CategoryId",
                table: "Transfers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Categories_CategoryId",
                table: "Transfers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Categories_CategoryId",
                table: "Transfers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_CategoryId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Transfers");

            migrationBuilder.AddColumn<string>(
                name: "Category_Category",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
