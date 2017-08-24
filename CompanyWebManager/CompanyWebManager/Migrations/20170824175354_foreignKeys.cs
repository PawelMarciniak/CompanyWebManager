using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class foreignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransactionDescriptionID",
                table: "Transactions",
                nullable: false
            );

            migrationBuilder.CreateIndex(
                name: "Transactions_TransactionDescriptionID",
                table: "Transactions",
                column: "TransactionDescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionDescriptions_TransactionDescriptionID",
                table: "Transactions",
                column: "TransactionDescriptionID",
                principalTable: "TransactionDescriptions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Transactions",
                nullable: false
            );
            
            migrationBuilder.CreateIndex(
                name: "Transactions_ProductID",
                table: "Transactions",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Transactions_TransactionDescriptionID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionDescriptions_TransactionDescriptionID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "Transactions_ProductID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions");
        }
    }
}
