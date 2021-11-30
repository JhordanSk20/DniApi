using DniApi.DataContext;
using DniApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DniApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _db;
        public PersonController(PersonContext db)
        {
            _db = db;
        }
        [HttpGet]
      
        public async Task<IActionResult> GetPerson()
        {
            var lista = await _db.Person.OrderBy(c => c.Nombre).ToListAsync();
            return Ok(lista);
        }
        [HttpPost]
       
        public async Task<IActionResult> CrearPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _db.AddAsync(person);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Dni:int}")]
        
        public async Task<IActionResult> GetPerson(string Dni)
        {
            var obj = await _db.Person.FirstOrDefaultAsync(c => c.Dni == Dni);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }
}
