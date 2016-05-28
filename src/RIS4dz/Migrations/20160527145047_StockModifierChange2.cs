using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace RIS4dz.Migrations
{
    public partial class StockModifierChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_FundOrder_Fund_FundID", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Fund_FundID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Stock_StockID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockOrder_Stock_StockID", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.AddForeignKey(
                name: "FK_FundOrder_Fund_FundID",
                table: "Order",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_StockOrder_Stock_StockID",
                table: "Order",
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
            migrationBuilder.DropForeignKey(name: "FK_FundOrder_Fund_FundID", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Fund_FundID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Stock_StockID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockOrder_Stock_StockID", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.AddForeignKey(
                name: "FK_FundOrder_Fund_FundID",
                table: "Order",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_StockOrder_Stock_StockID",
                table: "Order",
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
