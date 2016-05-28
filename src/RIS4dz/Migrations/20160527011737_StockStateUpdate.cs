using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace RIS4dz.Migrations
{
    public partial class StockStateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.DropColumn(name: "Value", table: "StockState");
            migrationBuilder.AddColumn<double>(
                name: "BuyRate",
                table: "StockState",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<double>(
                name: "SellRate",
                table: "StockState",
                nullable: false,
                defaultValue: 0);
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
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.DropColumn(name: "BuyRate", table: "StockState");
            migrationBuilder.DropColumn(name: "SellRate", table: "StockState");
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "StockState",
                nullable: false,
                defaultValue: 0);
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
