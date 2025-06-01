using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Focu.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    Slug = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    Amount = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    ExternalReference = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Gateway = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Voucher_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premium_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VoucherId",
                table: "Order",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_OrderId",
                table: "Premium",
                column: "OrderId");

            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW [vwGetIncomesAndExpenses] AS
                    SELECT
                        [Transactions].[UserId],
                        MONTH([Transactions].[PaidOrReceivedAt]) AS [Month],
                        YEAR([Transactions].[PaidOrReceivedAt]) AS [Year],
                        SUM(CASE WHEN [Transactions].[Type] = 1 THEN [Transactions].[Amount] ELSE 0 END) AS [Incomes],
                        SUM(CASE WHEN [Transactions].[Type] = 2 THEN [Transactions].[Amount] ELSE 0 END) AS [Expenses]
                    FROM
                        [Transactions]
                    WHERE
                        [Transactions].[PaidOrReceivedAt] >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
                        AND [Transactions].[PaidOrReceivedAt] < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
                    GROUP BY
                        [Transactions].[UserId],
                        MONTH([Transactions].[PaidOrReceivedAt]),
                        YEAR([Transactions].[PaidOrReceivedAt])
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW [vwGetExpensesByCategory] AS
                    SELECT
                        [Transactions].[UserId],
                        [Categories].[Title] AS [Categories],
                        YEAR([Transactions].[PaidOrReceivedAt]) AS [Year],
                        SUM([Transactions].[Amount]) AS [Expenses]
                    FROM
                        [Transactions] INNER JOIN [Categories] ON [Transactions].[CategoryId] = [Categories].[Id]
                    WHERE
                        [Transactions].[PaidOrReceivedAt]
                            >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
                      AND [Transactions].[PaidOrReceivedAt]
                        < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
                      AND [Transactions].[Type] = 2
                    GROUP BY
                        [Transactions].[UserId],
                        [Categories].[Title],
                        YEAR([Transactions].[PaidOrReceivedAt])
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW [vwGetIncomesByCategory] AS
                    SELECT
                        [Transactions].[UserId],
                        [Categories].[Title] AS [Categories],
                        YEAR([Transactions].[PaidOrReceivedAt]) AS [Year],
                        SUM([Transactions].[Amount]) AS [Incomes]
                    FROM
                        [Transactions] INNER JOIN [Categories] ON [Transactions].[CategoryId] = [Categories].[Id]
                    WHERE
                        [Transactions].[PaidOrReceivedAt] >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
                        AND [Transactions].[PaidOrReceivedAt] < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
                        AND [Transactions].[Type] = 1
                    GROUP BY
                        [Transactions].[UserId],
                        [Categories].[Title],
                        YEAR([Transactions].[PaidOrReceivedAt])
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS [vwGetIncomesAndExpenses]");
            migrationBuilder.Sql("DROP VIEW IF EXISTS [vwGetExpensesByCategory]");
            migrationBuilder.Sql("DROP VIEW IF EXISTS [vwGetIncomesByCategory]");

            migrationBuilder.DropTable(
                name: "Premium");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Voucher");
        }
    }
}
