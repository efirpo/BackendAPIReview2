using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShelter.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Admitted", "Age", "Breed", "Name", "Notes" },
                values: new object[,]
                {
                    { 2, new DateTime(1978, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, "American Shorthair", "Garfield", "Likes lasagna and summoning eldritch monstrosities." },
                    { 3, new DateTime(2015, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Siamese", "Grumpy Cat", "Special needs! Also fairly pessimistic." },
                    { 4, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Russian Grey", "Pusheen", "Needs a diet, surprisingly agile." }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Admitted", "Age", "Breed", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Terrier Mutt", "Doggo", "Who's a good doggo? Doggo is a good doggo!" },
                    { 2, new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Shepherd/Lab Mix", "Pupper", "Just a little pupperino." },
                    { 3, new DateTime(2018, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Pug", "The Right Honorable Charles Beauregard, Esq.", "Mr. Beauregard takes his tea with a smidge of cream and usually has a constitutional cigar after dinner." },
                    { 4, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "West Highland Terrier", "Buddy", "A real big jerk." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 4);
        }
    }
}
