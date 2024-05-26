using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCrafts.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Transaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CartItem",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_UserId",
                table: "CartItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_AspNetUsers_UserId",
                table: "CartItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_AspNetUsers_UserId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_UserId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CartItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
