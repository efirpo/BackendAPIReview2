using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShelter.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Admitted", "Age", "Breed", "Name", "Notes" },
                values: new object[] { 1, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "American Shorthair", "Macavity", "A mystery cat, a master criminal who can defy the law." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1);
        }
    }
}
