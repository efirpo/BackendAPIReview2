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
  public class CatsController : ControllerBase
  {
    private PetShelterContext _db;
    public CatsController(PetShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      return _db.Cats.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id)
    {
      var thisCat = _db.Cats.FirstOrDefault(c => c.CatId == id);
      return thisCat;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Cat>> Get(string name, string breed, Nullable<int> age, string notes, DateTime admitted)
    {
      var search = _db.Cats.AsQueryable();
      if (name != null)
      {
        search = search.Where(cat => cat.Name.ToLower().Contains(name.ToLower()));
      }
      if (breed != null)
      {
        search = search.Where(cat => cat.Breed.ToLower().Contains(breed.ToLower()));
      }
      if (age != null)
      {
        search = search.Where(cat => cat.Age == age);
      }
      if (notes != null)
      {
        search = search.Where(cat => cat.Notes.ToLower().Contains(notes.ToLower()));
      }
      if (admitted != new DateTime(0000, 00, 00))
      {
        DateTime now = DateTime.Now;
        TimeSpan elapsed = now.Subtract(admitted);
        search = search.Where(cat => now.Subtract(admitted) < now.Subtract(cat.Admitted));
      }
    }

    [HttpPost]
    public void Post([FromBody] Cat cat)
    {
      cat.Age = null;
      _db.Cats.Add(cat);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Cat cat)
    {
      cat.CatId = id;
      _db.Entry(cat).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var thisCat = _db.Cats.FirstOrDefault(c => c.CatId == id);
      _db.Cats.Remove(thisCat);
      _db.SaveChanges();
    }


  }
}