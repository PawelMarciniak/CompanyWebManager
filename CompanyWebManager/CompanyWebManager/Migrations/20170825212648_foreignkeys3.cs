using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class foreignkeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Transactions_OwnerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Owners_OwnerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "ownerID",
                table: "TransactionDescriptions",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "TransactionDescriptions_OwnerID",
                table: "TransactionDescriptions",
                column: "ownerID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDescriptions_Owners_OwnerID",
                table: "TransactionDescriptions",
                column: "ownerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ownerID",
                table: "Transactions",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "Transactions_OwnerID",
                table: "Transactions",
                column: "ownerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Owners_OwnerID",
                table: "Transactions",
                column: "ownerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropIndex(
                name: "TransactionDescriptions_OwnerID",
                table: "TransactionDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDescriptions_Owners_OwnerID",
                table: "TransactionDescriptions");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "TransactionDescriptions");
        }
    }
}
