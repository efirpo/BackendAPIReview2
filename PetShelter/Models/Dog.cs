using System;
using System.ComponentModel.DataAnnotations;

namespace PetShelter.Models
{
  public class Dog
  {
    public int DogId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Breed { get; set; }
    public Nullable<int> Age { get; set; }
    [Required]
    public DateTime Admitted { get; set; }
    public string Notes { get; set; }
  }
}