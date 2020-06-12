using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShelter.Models;

namespace PetShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DogsController : ControllerBase
  {
    private PetShelterContext _db;
    public DogsController(PetShelterContext db)
    {
      _db = db;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Dog>> Get(string name, string breed, Nullable<int> age, string notes, DateTime admitted)
    {
      var search = _db.Dogs.AsQueryable();
      if (name != null)
      {
        search = search.Where(dog => dog.Name.ToLower().Contains(name.ToLower()));
      }
      if (breed != null)
      {
        search = search.Where(dog => dog.Breed.ToLower().Contains(breed.ToLower()));
      }
      if (age != null)
      {
        search = search.Where(dog => dog.Age == age);
      }
      if (notes != null)
      {
        search = search.Where(dog => dog.Notes.ToLower().Contains(notes.ToLower()));
      }
      var zeroDate = new DateTime();
      if (admitted.Equals(zeroDate))
      {
      }
      else
      {
        DateTime now = DateTime.Now;
        search = search.Where(dog => (now.Subtract(admitted)).TotalDays >= (now.Subtract(dog.Admitted)).TotalDays);
      }
      return search.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Dog dog)
    {
      _db.Dogs.Add(dog);
      _db.SaveChanges();
    }
    [HttpGet("{id}")]

    public ActionResult<Dog> Get(int id)
    {
      var thisDog = _db.Dogs.FirstOrDefault(d => d.DogId == id);
      return thisDog;
    }

    [HttpPut("{id}")]

    public void Put(int id, [FromBody] Dog dog)
    {
      var thisDog = _db.Dogs.FirstOrDefault(d => d.DogId == id);
      if (dog.Name != null)
      {
        thisDog.Name = dog.Name;
      }
      if (dog.Age != null)
      {
        thisDog.Age = dog.Age;
      }
      if (dog.Breed != null)
      {
        thisDog.Breed = dog.Breed;
      }
      var zeroDate = new DateTime();
      if (dog.Admitted.Equals(zeroDate))
      {
      }
      else
      {
        thisDog.Admitted = dog.Admitted;
      }
      if (dog.Notes != null)
      {
        thisDog.Notes = dog.Notes;
      }
      _db.Entry(thisDog).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]

    public void Delete(int id)
    {
      var thisDog = _db.Dogs.FirstOrDefault(d => d.DogId == id);
      _db.Dogs.Remove(thisDog);
      _db.SaveChanges();
    }
  }
}

