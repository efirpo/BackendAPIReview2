using System;

namespace PetShelter.Models
{
  public class Dog
  {
    public int DogId { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public Nullable<int> Age { get; set; }
    public DateTime Admitted { get; set; }
    public string Notes { get; set; }
  }
}