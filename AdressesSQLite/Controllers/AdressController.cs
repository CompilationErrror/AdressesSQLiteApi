using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdressesSQLite.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace AdressesSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly DataContext _context;

        public AdressController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Adress>>> AddAdress(
            Adress adress)
        {
            _context.Adresses.Add(adress);
            await _context.SaveChangesAsync();

            return Ok(await _context.Adresses.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Adress>>> GetAllAdresses([FromQuery] string? sortField, [FromQuery] int wayOfOrder = 1)
        {
            sortField ??= "Empty";
            sortField.ToLower();
            if (wayOfOrder == 1)
            {
                
                switch (sortField)
                {
                    case "street":
                        return Ok(await _context.Adresses
                            .OrderBy(pr => pr.Street.Length)
                            .ThenBy(p => p).ToListAsync());
                    case "house number":
                        return Ok(await _context.Adresses
                            .OrderBy(pr => pr.HouseNumber.Length)
                            .ThenBy(p => p).ToListAsync());
                    case "zip code":
                        return Ok(await _context.Adresses
                            .OrderBy(pr => pr.ZipCode.Length)
                            .ThenBy(p => p).ToListAsync());
                    case "country":
                        return Ok(await _context.Adresses
                            .OrderBy(pr => pr.Country.Length)
                            .ThenBy(p => p).ToListAsync());
                    case "city":
                        return Ok(await _context.Adresses
                            .OrderBy(pr => pr.City.Length)
                            .ThenBy(p => p).ToListAsync());
                }
            }
            else if (wayOfOrder == 2)
                switch (sortField)
                {
                    case "street":
                        return Ok(await _context.Adresses
                            .OrderByDescending(pr => pr.Street.Length)
                            .ThenByDescending(p => p).ToListAsync());
                    case "house number":
                        return Ok(await _context.Adresses
                            .OrderByDescending(pr => pr.HouseNumber.Length)
                            .ThenByDescending(p => p).ToListAsync());
                    case "zip code":
                        return Ok(await _context.Adresses
                            .OrderByDescending(pr => pr.ZipCode.Length)
                            .ThenByDescending(p => p).ToListAsync());
                    case "country":
                        return Ok(await _context.Adresses
                            .OrderByDescending(pr => pr.Country.Length)
                            .ThenByDescending(p => p).ToListAsync());
                    case "city":
                        return Ok(await _context.Adresses
                            .OrderByDescending(pr => pr.City.Length)
                            .ThenByDescending(p => p).ToListAsync());
                    default:
                        return Ok(await _context.Adresses
                            .OrderByDescending(pr => pr.Id).ToListAsync());
                }
            return Ok(await _context.Adresses.OrderBy(pr=>pr.Id).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Adress>>> GetAdress(int id)
        {
            var adress = await _context.Adresses.FindAsync(id);
            if (adress == null)
            {
                return BadRequest("Adress not found!");
            }
            return Ok(adress);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Adress>>> UpdateAdress(
            int id, Adress adress)
        {
            if (id != adress.Id) 
                return BadRequest("Adress not found!");
            _context.Entry(adress).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Adress>>> DeleteAdress(
            int id)
        {
            var adressToDelete = await _context.Adresses.FindAsync(id);
            if (adressToDelete == null)
                return NotFound();
            _context.Adresses.Remove(adressToDelete);
            await _context.SaveChangesAsync();    
            return NoContent();
        }
    }
}
