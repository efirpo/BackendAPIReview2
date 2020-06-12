using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
  }
}
