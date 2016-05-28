using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace RIS4dz.Migrations
{
    public partial class Fund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StockState_Stock_StockID", table: "StockState");
            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "StockMultiplyer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FundID = table.Column<int>(nullable: false),
                    Multiplyer = table.Column<int>(nullable: false),
                    StockID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMultiplyer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockMultiplyer_Fund_FundID",
                        column: x => x.FundID,
                        principalTable: "Fund",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockMultiplyer_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
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
            migrationBuilder.DropTable("StockMultiplyer");
            migrationBuilder.DropTable("Fund");
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
