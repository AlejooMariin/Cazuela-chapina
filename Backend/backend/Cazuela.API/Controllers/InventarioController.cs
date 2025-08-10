using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CazuelaChapina.Data;
using CazuelaChapina.Models;

namespace CazuelaChapina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Materias primas
        [HttpGet("materias-primas")]
        public async Task<ActionResult<IEnumerable<MateriaPrima>>> GetMateriasPrimas()
        {
            return await _context.MateriasPrimas.ToListAsync();
        }

        [HttpPost("materias-primas")]
        public async Task<ActionResult<MateriaPrima>> PostMateriaPrima(MateriaPrima materiaPrima)
        {
            _context.MateriasPrimas.Add(materiaPrima);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMateriasPrimas), new { id = materiaPrima.Id }, materiaPrima);
        }

        [HttpPut("materias-primas/{id}")]
        public async Task<IActionResult> PutMateriaPrima(int id, MateriaPrima materiaPrima)
        {
            if (id != materiaPrima.Id)
                return BadRequest();

            _context.Entry(materiaPrima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MateriasPrimas.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("materias-primas/{id}")]
        public async Task<IActionResult> DeleteMateriaPrima(int id)
        {
            var materiaPrima = await _context.MateriasPrimas.FindAsync(id);
            if (materiaPrima == null)
                return NotFound();

            _context.MateriasPrimas.Remove(materiaPrima);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Movimientos inventario
        [HttpGet("movimientos")]
        public async Task<ActionResult<IEnumerable<InventarioMovimiento>>> GetMovimientos()
        {
            return await _context.InventarioMovimientos.ToListAsync();
        }

        [HttpPost("movimientos")]
        public async Task<ActionResult<InventarioMovimiento>> PostMovimiento(InventarioMovimiento movimiento)
        {
            _context.InventarioMovimientos.Add(movimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovimientos), new { id = movimiento.Id }, movimiento);
        }

        [HttpDelete("movimientos/{id}")]
        public async Task<IActionResult> DeleteMovimiento(int id)
        {
            var movimiento = await _context.InventarioMovimientos.FindAsync(id);
            if (movimiento == null)
                return NotFound();

            _context.InventarioMovimientos.Remove(movimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
