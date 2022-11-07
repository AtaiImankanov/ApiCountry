using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCountry.Models;

namespace WebApplicationCountry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryContext _context;

        public CountryController(CountryContext context)
        {
            _context = context;
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { NameOfCountry = "Kyrgyzstan" });
                _context.Countries.Add(new Country { NameOfCountry = "Kazahstan"});
                _context.Countries.Add(new Country { NameOfCountry = "Russia" });
                _context.Countries.Add(new Country { NameOfCountry = "USA" });
                _context.Countries.Add(new Country { NameOfCountry = "Mexico"});
                _context.Countries.Add(new Country { NameOfCountry = "Uzbekistan"});
                _context.Countries.Add(new Country { NameOfCountry = "Turkey" });
                _context.Countries.Add(new Country { NameOfCountry = "Kanada"});
                _context.Countries.Add(new Country { NameOfCountry = "Singapoure"});
                _context.Countries.Add(new Country { NameOfCountry = "Niger" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
                return NotFound();
            return new ObjectResult(country);
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<Country>> Get(string name)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.NameOfCountry == name);
            if (country == null)
                return NotFound();
            return new ObjectResult(country);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Post(Country country)
        {
            if (country == null)
                return BadRequest();
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult<Country>> Put(Country country)
        {
            if (country == null)
                return BadRequest();
            if (!_context.Countries.Any(c => c.Id == c.Id))
                return NotFound();
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> Delete(int id)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
                return NotFound();
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}

