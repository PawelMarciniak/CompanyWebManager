using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyWebManager.Migrations
{
    public partial class foreignkeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ownerID",
                table: "Clients",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "Clients_OwnerID",
                table: "Clients",
                column: "ownerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Owners_OwnerID",
                table: "Clients",
                column: "ownerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddColumn<int>(
                name: "ownerID",
                table: "Employees",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "Employees_OwnerID",
                table: "Employees",
                column: "ownerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Owners_OwnerID",
                table: "Employees",
                column: "ownerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddColumn<int>(
                name: "ownerID",
                table: "Products",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "Products_OwnerID",
                table: "Products",
                column: "ownerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Owners_OwnerID",
                table: "Products",
                column: "ownerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "Clients_OwnerID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Owners_OwnerID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "Employees_OwnerID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Owners_OwnerID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "Products_OwnerID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Owners_OwnerID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "Transactions_OwnerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Owners_OwnerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "Transactions");

        }
    }
}
