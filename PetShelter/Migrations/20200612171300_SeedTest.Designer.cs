﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShelter.Models;

namespace PetShelter.Migrations
{
    [DbContext(typeof(PetShelterContext))]
    [Migration("20200612171300_SeedTest")]
    partial class SeedTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PetShelter.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Admitted");

                    b.Property<int>("Age");

                    b.Property<string>("Breed");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("CatId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            Admitted = new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Age = 6,
                            Breed = "American Shorthair",
                            Name = "Macavity",
                            Notes = "A mystery cat, a master criminal who can defy the law."
                        });
                });

            modelBuilder.Entity("PetShelter.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Admitted");

                    b.Property<int>("Age");

                    b.Property<string>("Breed");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");
                });
#pragma warning restore 612, 618
        }
    }
}
