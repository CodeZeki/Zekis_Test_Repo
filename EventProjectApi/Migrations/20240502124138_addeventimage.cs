﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class addeventimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventImage",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventImage",
                table: "Events");
        }
    }
}
