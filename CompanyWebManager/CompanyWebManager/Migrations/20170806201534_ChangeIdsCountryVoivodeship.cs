using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyWebManager.Migrations
{
    public partial class ChangeIdsCountryVoivodeship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Companies_CountryID",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_VoivodeshipID",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CountryID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_VoivodeshipID",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "VoivodeshipID",
                table: "Employees",
                newName: "Voivodeship");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Employees",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "VoivodeshipID",
                table: "Companies",
                newName: "Voivodeship");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Companies",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "VoivodeshipID",
                table: "Clients",
                newName: "Voivodeship");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Clients",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Voivodeship",
                table: "Employees",
                newName: "VoivodeshipID");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Employees",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "Voivodeship",
                table: "Companies",
                newName: "VoivodeshipID");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Companies",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "Voivodeship",
                table: "Clients",
                newName: "VoivodeshipID");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Clients",
                newName: "CountryID");


            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryID",
                table: "Companies",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_VoivodeshipID",
                table: "Companies",
                column: "VoivodeshipID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CountryID",
                table: "Clients",
                column: "CountryID");

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
        }
    }
}
