using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class TransactionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transactions",
                newName: "TransactionDescriptionID");

            migrationBuilder.RenameColumn(
                name: "ProductNetPrice",
                table: "Transactions",
                newName: "UnitNetPrice");

            migrationBuilder.RenameColumn(
                name: "ProductGrossPrice",
                table: "Transactions",
                newName: "UnitGrossPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "GrossPrice",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetPrice",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TransactionID",
                table: "Products",
                column: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Transactions_TransactionID",
                table: "Products",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Transactions_TransactionID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TransactionID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GrossPrice",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "NetPrice",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitNetPrice",
                table: "Transactions",
                newName: "ProductNetPrice");

            migrationBuilder.RenameColumn(
                name: "UnitGrossPrice",
                table: "Transactions",
                newName: "ProductGrossPrice");

            migrationBuilder.RenameColumn(
                name: "TransactionDescriptionID",
                table: "Transactions",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
