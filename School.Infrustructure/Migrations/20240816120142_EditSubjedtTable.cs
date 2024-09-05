﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSubjedtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "StudentSubjects",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentSubjects");
        }
    }
}
