using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventfulPeace.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Application");

            migrationBuilder.CreateTable(
                name: "Invitations",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OccursAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Application",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06102732-56c9-425b-831a-cf2d8de5476c"), "Stara Zagora" },
                    { new Guid("0ff3a9fb-1c7e-4313-bf81-6bfe5c05445d"), "Montana" },
                    { new Guid("233a5b44-aefd-4163-94ac-7c9d921d8129"), "Plovdiv" },
                    { new Guid("2885a542-2b35-4cd3-9cfa-2ebf23e80ea1"), "Pazardjik" },
                    { new Guid("2a316f7e-0112-4815-8033-18c6cda5f3b6"), "Haskovo" },
                    { new Guid("2bf2c22b-325b-42e5-ae3e-23a20c69408d"), "Kardjali" },
                    { new Guid("2d562197-83b2-472e-a5d7-8ee789b4cfc3"), "Targovishte" },
                    { new Guid("30822e93-9470-4f10-b6ae-70a2f512228a"), "Shumen" },
                    { new Guid("42a6aff1-d977-4ef0-90ca-097ebeeb4eea"), "Veliko Tarnovo" },
                    { new Guid("4402ee9e-8b3e-45c1-859e-c7c707be1fd1"), "Smolyan" },
                    { new Guid("51e0aff1-47fa-4f3b-82a0-b41fa2851a58"), "Ruse" },
                    { new Guid("5f035f95-28bd-4cee-ae2d-40c921f29a1d"), "Razgrad" },
                    { new Guid("60dc9276-4645-4098-866e-0dc330829d3e"), "Pernik" },
                    { new Guid("67ef3033-def7-4211-8f09-a03243a33fff"), "Sliven" },
                    { new Guid("84b77c7d-f9d4-4e85-a468-67fc3a60a124"), "Kyustendil" },
                    { new Guid("8b921b20-b3c5-469a-b01c-4683c3a885a7"), "Varna" },
                    { new Guid("9da8e2be-fcd9-408e-93a7-aeda0febafef"), "Yambol" },
                    { new Guid("a77afb62-ec0c-4322-9ea7-474641d76164"), "Blagoevgrad" },
                    { new Guid("ac80410e-d7f5-41cc-92de-649bc134c963"), "Lovech" },
                    { new Guid("b54800f9-a8d7-4200-ba0a-04ea90919374"), "Vidin" },
                    { new Guid("b60131ca-1d56-4e4e-b43e-b68eed269473"), "Burgas" },
                    { new Guid("be84bfbb-2aa8-40be-a028-99ec8c07c7fa"), "Pleven" },
                    { new Guid("c9c7eed3-189a-419d-8dc3-ecae6a41aa77"), "Vratsa" },
                    { new Guid("e3c0e30b-5587-4c1a-a864-db1d66a9c3e0"), "Sofia" },
                    { new Guid("f6ef9357-e048-4ee4-b7e3-82082d304b93"), "Dobrich" },
                    { new Guid("faf4e858-44ad-40bc-98f1-2e0e7b9e65f1"), "Gabrovo" }
                });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "LocationId", "Name", "OccursAt" },
                values: new object[,]
                {
                    { new Guid("762ddec2-25c9-4183-9891-72a19d84a839"), new DateTime(2025, 3, 4, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90"), "Welcome to our not-like-the-others Martenitsa Workshop!", new Guid("b60131ca-1d56-4e4e-b43e-b68eed269473"), "Martenitsa Workshop", new DateTime(2025, 3, 3, 15, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e1101e2c-32cc-456f-9c82-4f1d1a65d141"), new DateTime(2025, 3, 4, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("2c7667ad-716b-4606-b50d-a370ecdb1a00"), "Endulge in various cuisines, carefully prepared by the best of street food cooks", new Guid("e3c0e30b-5587-4c1a-a864-db1d66a9c3e0"), "Street Food Festeival", new DateTime(2025, 3, 21, 19, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"), new DateTime(2025, 3, 4, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("7f6e3868-ca03-44d6-b4a3-d947ac012ca6"), "Gaze at the stars through the lenses of professional telescopes and witness the beauty of the night sky", new Guid("233a5b44-aefd-4163-94ac-7c9d921d8129"), "Astronomical View", new DateTime(2025, 4, 5, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("fad1b19d-5333-4633-bd84-d67c64649f65"), new DateTime(2025, 3, 4, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("7f6e3868-ca03-44d6-b4a3-d947ac012ca6"), "A sport event for all nature lovers, with a route through picturesque greenery", new Guid("42a6aff1-d977-4ef0-90ca-097ebeeb4eea"), "The Greenery Challenge", new DateTime(2025, 5, 5, 8, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                schema: "Application",
                table: "Events",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Invitations",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Application");
        }
    }
}
