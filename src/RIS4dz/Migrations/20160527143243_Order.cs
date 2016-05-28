using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace RIS4dz.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Fund_FundID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Stock_StockID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOrdered = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ShareValueAtOrder = table.Column<double>(nullable: false),
                    TotalValueAtOrder = table.Column<double>(nullable: false),
                    TransactionFee = table.Column<double>(nullable: false),
                    numberOfShares = table.Column<int>(nullable: false),
                    FundID = table.Column<int>(nullable: true),
                    StockID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FundOrder_Fund_FundID",
                        column: x => x.FundID,
                        principalTable: "Fund",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockOrder_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_StockMultiplyer_Fund_FundID",
                table: "StockMultiplyer",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_StockMultiplyer_Stock_StockID",
                table: "StockMultiplyer",
                column: "StockID",
                principalTable: "Stock",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_StockState_Stock_StockID",
                table: "StockState",
                column: "StockID",
                principalTable: "Stock",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Fund_FundID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Stock_StockID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.DropTable("Order");
            migrationBuilder.AddForeignKey(
                name: "FK_StockMultiplyer_Fund_FundID",
                table: "StockMultiplyer",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_StockMultiplyer_Stock_StockID",
                table: "StockMultiplyer",
                column: "StockID",
                principalTable: "Stock",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_StockState_Stock_StockID",
                table: "StockState",
                column: "StockID",
                principalTable: "Stock",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
