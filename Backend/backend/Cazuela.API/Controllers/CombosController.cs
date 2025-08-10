using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CazuelaChapina.Data;
using CazuelaChapina.Models;

namespace CazuelaChapina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CombosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CombosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Combo>>> GetCombos()
        {
            return await _context.Combos
                .Include(c => c.Tamales)
                .Include(c => c.Bebidas)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Combo>> GetCombo(int id)
        {
            var combo = await _context.Combos
                .Include(c => c.Tamales)
                .Include(c => c.Bebidas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (combo == null)
                return NotFound();

            return combo;
        }

        [HttpPost]
        public async Task<ActionResult<Combo>> PostCombo(Combo combo)
        {
            _context.Combos.Add(combo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCombo), new { id = combo.Id }, combo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCombo(int id, Combo combo)
        {
            if (id != combo.Id)
                return BadRequest();

            _context.Entry(combo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Combos.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCombo(int id)
        {
            var combo = await _context.Combos.FindAsync(id);
            if (combo == null)
                return NotFound();

            _context.Combos.Remove(combo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
