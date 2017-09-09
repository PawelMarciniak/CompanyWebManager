using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class nochanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ownerID",
            //    table: "Transactions");

            //migrationBuilder.RenameColumn(
            //    name: "OwnerID",
            //    table: "Companies",
            //    newName: "ownerID");

            //migrationBuilder.AddColumn<int>(
            //    name: "ownerID",
            //    table: "TransactionDescriptions",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ownerID",
            //    table: "TransactionDescriptions");

            //migrationBuilder.RenameColumn(
            //    name: "ownerID",
            //    table: "Companies",
            //    newName: "OwnerID");

            //migrationBuilder.AddColumn<int>(
            //    name: "ownerID",
            //    table: "Transactions",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
