using Microsoft.EntityFrameworkCore;
using System;

namespace PetShelter.Models
{
  public class PetShelterContext : DbContext
  {
    public PetShelterContext(DbContextOptions<PetShelterContext> options)
        : base(options)
    {
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cat>()
      .HasData(
        new Cat { CatId = 1, Name = "Macavity", Breed = "American Shorthair", Age = 6, Admitted = new DateTime(2019, 01, 02), Notes = "A mystery cat, a master criminal who can defy the law." },
        new Cat { CatId = 2, Name = "Garfield", Breed = "American Shorthair", Age = 42, Admitted = new DateTime(1978, 06, 19), Notes = "Likes lasagna and summoning eldritch monstrosities." },
        new Cat { CatId = 3, Name = "Grumpy Cat", Breed = "Siamese", Age = 9, Admitted = new DateTime(2015, 07, 27), Notes = "Special needs! Also fairly pessimistic." },
        new Cat { CatId = 4, Name = "Pusheen", Breed = "Russian Grey", Age = 3, Admitted = new DateTime(2020, 03, 12), Notes = "Needs a diet, surprisingly agile." }

      );
      builder.Entity<Dog>()
      .HasData(
        new Dog { DogId = 1, Name = "Doggo", Breed = "Terrier Mutt", Age = 4, Admitted = new DateTime(2019, 11, 04), Notes = "Who's a good doggo? Doggo is a good doggo!" },
        new Dog { DogId = 2, Name = "Pupper", Breed = "Shepherd/Lab Mix", Age = 1, Admitted = new DateTime(2020, 04, 11), Notes = "Just a little pupperino." },
        new Dog { DogId = 3, Name = "The Right Honorable Charles Beauregard, Esq.", Breed = "Pug", Age = 10, Admitted = new DateTime(2018, 04, 25), Notes = "Mr. Beauregard takes his tea with a smidge of cream and usually has a constitutional cigar after dinner." },
        new Dog { DogId = 4, Name = "Buddy", Breed = "West Highland Terrier", Age = 2, Admitted = new DateTime(2015, 11, 02), Notes = "A real big jerk." }
      );
    }
  }
}