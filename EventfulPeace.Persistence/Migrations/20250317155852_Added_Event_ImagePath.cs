using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventfulPeace.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Event_ImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "Application",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Application",
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("762ddec2-25c9-4183-9891-72a19d84a839"),
                column: "ImagePath",
                value: "images/Martenitsa Workshop-762ddec2-25c9-4183-9891-72a19d84a839.jpg");

            migrationBuilder.UpdateData(
                schema: "Application",
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e1101e2c-32cc-456f-9c82-4f1d1a65d141"),
                column: "ImagePath",
                value: "images/Street Food Festeival-e1101e2c-32cc-456f-9c82-4f1d1a65d141.jpg");

            migrationBuilder.UpdateData(
                schema: "Application",
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"),
                column: "ImagePath",
                value: "images/Astronomical View-f3ad41d3-ee90-4988-9195-8b2a8f4f2733.webp");

            migrationBuilder.UpdateData(
                schema: "Application",
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fad1b19d-5333-4633-bd84-d67c64649f65"),
                column: "ImagePath",
                value: "images/The Greenery Challenge-fad1b19d-5333-4633-bd84-d67c64649f65.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "Application",
                table: "Events");
        }
    }
}
