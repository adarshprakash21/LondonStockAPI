using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LondonStockAPI.Migrations
{
    /// <inheritdoc />
    public partial class addRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "Trades",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Broker",
                columns: new[] { "BrokerId", "Name" },
                values: new object[,]
                {
                    { 1, "Zerodha" },
                    { 2, "Upstox" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Ticker", "Name" },
                values: new object[,]
                {
                    { "AAPL", "Apple Inc." },
                    { "F", "Ford Motor Company" },
                    { "GOOGL", "Alphabet Inc" },
                    { "MSFT", "Microsoft Corp." },
                    { "TSLA", "Tesla, Inc." },
                    { "WMT", "Walmart" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_BrokerId",
                table: "Trades",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_Ticker",
                table: "Trades",
                column: "Ticker");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Broker_BrokerId",
                table: "Trades",
                column: "BrokerId",
                principalTable: "Broker",
                principalColumn: "BrokerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Stocks_Ticker",
                table: "Trades",
                column: "Ticker",
                principalTable: "Stocks",
                principalColumn: "Ticker",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Broker_BrokerId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Stocks_Ticker",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_BrokerId",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_Ticker",
                table: "Trades");

            migrationBuilder.DeleteData(
                table: "Broker",
                keyColumn: "BrokerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Broker",
                keyColumn: "BrokerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "AAPL");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "F");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "GOOGL");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "MSFT");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "TSLA");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "WMT");

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "Trades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
