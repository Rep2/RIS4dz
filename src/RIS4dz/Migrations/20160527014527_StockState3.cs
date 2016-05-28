using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace RIS4dz.Migrations
{
    public partial class StockState3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.DropColumn(name: "Value", table: "Stock");
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stock",
                nullable: false);
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Stock_Name",
                table: "Stock",
                column: "Name");
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
            migrationBuilder.DropUniqueConstraint(name: "AK_Stock_Name", table: "Stock");
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stock",
                nullable: true);
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Stock",
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
