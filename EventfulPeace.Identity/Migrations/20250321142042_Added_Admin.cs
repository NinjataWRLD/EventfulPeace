using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventfulPeace.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Added_Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("fab1b19d-5333-4633-bd84-d67c64649f65"), "d6c9b3d1-8c3d-4a7e-8d6b-1b2c9c9c9c9c", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5940d6f-d5c0-4f84-a262-da9b07525c3c", "AQAAAAIAAYagAAAAEEUe31maWfuZY6V8MQBzUWKerMKobDukREinVfML3Yl2z+Nr6IIQZKvX4WKqbTUw6w==", "FNNIT3NPOZKZK2E67WFLV5R3RGVBX7LV" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90"), 0, "5c94b43f-861c-4efa-a670-5627e49d354d", "admin123@gmail.com", true, true, null, "ADMIN123@GMAIL.COM", "ADMIN123", "AQAAAAIAAYagAAAAEFqtQ33BvarNRyFcmV4z48fPBlIY8zd0de90qq3Cdm1Row+2WRmEjVJk1yPadBkrSA==", null, true, "YIA26UZDSN2V2U5PVDEK4F3EJS3P5D3X", false, "Admin123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fab1b19d-5333-4633-bd84-d67c64649f65"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90"));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c94b43f-861c-4efa-a670-5627e49d354d", "AQAAAAIAAYagAAAAEFqtQ33BvarNRyFcmV4z48fPBlIY8zd0de90qq3Cdm1Row+2WRmEjVJk1yPadBkrSA==", "YIA26UZDSN2V2U5PVDEK4F3EJS3P5D3X" });
        }
    }
}
