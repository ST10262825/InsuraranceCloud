using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCrafts.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "Transaction",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "Transaction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Transaction",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpirationMonth",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpirationYear",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ExpirationMonth",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ExpirationYear",
                table: "Transaction");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Transaction",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transaction",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Transaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
