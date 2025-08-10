using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CazuelaChapina.Data;
using CazuelaChapina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CazuelaChapina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TamalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TamalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tamales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tamal>>> GetTamales()
        {
            return await _context.Tamales.ToListAsync();
        }

        // GET: api/tamales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tamal>> GetTamal(int id)
        {
            var tamal = await _context.Tamales.FindAsync(id);

            if (tamal == null)
            {
                return NotFound();
            }

            return tamal;
        }

        // POST: api/tamales
        [HttpPost]
        public async Task<ActionResult<Tamal>> PostTamal(Tamal tamal)
        {
            _context.Tamales.Add(tamal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTamal), new { id = tamal.Id }, tamal);
        }

        // PUT: api/tamales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTamal(int id, Tamal tamal)
        {
            if (id != tamal.Id)
            {
                return BadRequest();
            }

            _context.Entry(tamal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/tamales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTamal(int id)
        {
            var tamal = await _context.Tamales.FindAsync(id);
            if (tamal == null)
            {
                return NotFound();
            }

            _context.Tamales.Remove(tamal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TamalExists(int id)
        {
            return _context.Tamales.Any(e => e.Id == id);
        }
    }
}
