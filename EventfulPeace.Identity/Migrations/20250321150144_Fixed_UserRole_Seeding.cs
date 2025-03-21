using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventfulPeace.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_UserRole_Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"), new Guid("2c7667ad-716b-4606-b50d-a370ecdb1a00") },
                    { new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"), new Guid("7f6e3868-ca03-44d6-b4a3-d947ac012ca6") },
                    { new Guid("fad1b19d-5333-4633-bd84-d67c64649f65"), new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90") },
                    { new Guid("fab1b19d-5333-4633-bd84-d67c64649f65"), new Guid("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"), new Guid("2c7667ad-716b-4606-b50d-a370ecdb1a00") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"), new Guid("7f6e3868-ca03-44d6-b4a3-d947ac012ca6") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fad1b19d-5333-4633-bd84-d67c64649f65"), new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fab1b19d-5333-4633-bd84-d67c64649f65"), new Guid("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90") });
        }
    }
}
