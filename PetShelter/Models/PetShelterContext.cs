using Microsoft.EntityFrameworkCore;

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
  }
}