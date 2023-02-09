﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyDocs.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingLinkCodeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkCode",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkCode",
                table: "Users");
        }
    }
}