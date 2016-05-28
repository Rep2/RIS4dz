using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace RIS4dz.Migrations
{
    public partial class StockModifierChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Fund_FundID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockMultiplyer_Stock_StockID", table: "StockMultiplyer");
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.AlterColumn<double>(
                name: "Multiplyer",
                table: "StockMultiplyer",
                nullable: false);
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
            migrationBuilder.AlterColumn<int>(
                name: "Multiplyer",
                table: "StockMultiplyer",
                nullable: false);
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
