using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class DeleteEntitiesFromEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Voivodeships_VoivodeshipID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CountryID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_VoivodeshipID",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryID",
                table: "Employees",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VoivodeshipID",
                table: "Employees",
                column: "VoivodeshipID");

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
    }
}
