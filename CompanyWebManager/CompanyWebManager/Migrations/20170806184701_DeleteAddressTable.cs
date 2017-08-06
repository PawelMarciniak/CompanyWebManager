using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class DeleteAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_CompanyID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AddressID",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Owners_OwnerID",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AddressID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Owners");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Owners_Addresses_AddressID",
            //    table: "Owners");




            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryID",
                table: "Employees",
                column: "CountryID");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Companies",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OwnerID",
                table: "Companies",
                newName: "IX_Companies_CountryID");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Clients",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CompanyID",
                table: "Clients",
                newName: "IX_Clients_CountryID");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoivodeshipID",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoivodeshipID",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoivodeshipID",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VoivodeshipID",
                table: "Employees",
                column: "VoivodeshipID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_VoivodeshipID",
                table: "Companies",
                column: "VoivodeshipID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_VoivodeshipID",
                table: "Clients",
                column: "VoivodeshipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Countries_CountryID",
                table: "Clients",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Voivodeships_VoivodeshipID",
                table: "Clients",
                column: "VoivodeshipID",
                principalTable: "Voivodeships",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountryID",
                table: "Companies",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Voivodeships_VoivodeshipID",
                table: "Companies",
                column: "VoivodeshipID",
                principalTable: "Voivodeships",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryID",
                table: "Employees",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Voivodeships_VoivodeshipID",
                table: "Employees",
                column: "VoivodeshipID",
                principalTable: "Voivodeships",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Countries_CountryID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Voivodeships_VoivodeshipID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountryID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Voivodeships_VoivodeshipID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Voivodeships_VoivodeshipID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_VoivodeshipID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Companies_VoivodeshipID",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Clients_VoivodeshipID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "VoivodeshipID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "VoivodeshipID",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "VoivodeshipID",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Employees",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CountryID",
                table: "Employees",
                newName: "IX_Employees_AddressID");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Companies",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CountryID",
                table: "Companies",
                newName: "IX_Companies_OwnerID");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Clients",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CountryID",
                table: "Clients",
                newName: "IX_Clients_CompanyID");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressID",
                table: "Owners",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressID",
                table: "Companies",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_CompanyID",
                table: "Clients",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressID",
                table: "Companies",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Owners_OwnerID",
                table: "Companies",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AddressID",
                table: "Employees",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
