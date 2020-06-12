using System.Collections.Generic;
using System.Linq;
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
    public ActionResult<IEnumerable<Dog>> Get()
    {
      return _db.Dogs.ToList();
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
      dog.DogId = id;
      _db.Entry(dog).State = EntityState.Modified;
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

