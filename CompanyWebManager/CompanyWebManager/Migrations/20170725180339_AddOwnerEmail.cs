using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class AddOwnerEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerEmail",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlindCarbonCopy",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarbonCopy",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "Emails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerEmail",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "BlindCarbonCopy",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "CarbonCopy",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Emails");
        }
    }
}
