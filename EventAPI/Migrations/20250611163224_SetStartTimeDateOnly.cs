using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPI.Migrations
{
    /// <inheritdoc />
    public partial class SetStartTimeDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("7cceaa27-c1bc-4ca8-b208-ac2144276731"));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "StartTime", "Title" },
                values: new object[] { new Guid("23838bc5-e06c-47c1-9193-645884db6710"), "Description for a seeded event", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Event" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("23838bc5-e06c-47c1-9193-645884db6710"));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "StartTime", "Title" },
                values: new object[] { new Guid("7cceaa27-c1bc-4ca8-b208-ac2144276731"), "Description for a seeded event", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Event" });
        }
    }
}
