using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PetShelter.Models
{
  public class Cat
  {
    public int CatId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Breed { get; set; }
    public Nullable<int> Age { get; set; }
    [Required]
    public DateTime Admitted { get; set; }
    public string Notes { get; set; }
  }
}