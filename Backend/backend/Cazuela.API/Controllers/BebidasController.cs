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
    public class BebidasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BebidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {
            return await _context.Bebidas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);

            if (bebida == null)
            {
                return NotFound();
            }

            return bebida;
        }

        [HttpPost]
        public async Task<ActionResult<Bebida>> PostBebida(Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBebida), new { id = bebida.Id }, bebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBebida(int id, Bebida bebida)
        {
            if (id != bebida.Id)
            {
                return BadRequest();
            }

            _context.Entry(bebida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BebidaExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBebida(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }

            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BebidaExists(int id)
        {
            return _context.Bebidas.Any(e => e.Id == id);
        }
    }
}
