using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CazuelaChapina.Data;
using CazuelaChapina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CazuelaChapina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CombosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/combos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Combo>>> GetCombos()
        {
            return await _context.Combos
                .Include(c => c.Tamales)   // incluir relaciones
                .Include(c => c.Bebidas)
                .ToListAsync();
        }

        // GET: api/combos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Combo>> GetCombo(int id)
        {
            var combo = await _context.Combos
                .Include(c => c.Tamales)
                .Include(c => c.Bebidas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (combo == null)
                return NotFound(new { mensaje = $"Combo con id {id} no encontrado" });

            return combo;
        }

        // POST: api/combos
        [HttpPost]
        public async Task<ActionResult<Combo>> CrearCombo(Combo combo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Combos.Add(combo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCombo), new { id = combo.Id }, combo);
        }

        // PUT: api/combos/5  -> Aquí puedes modificar el combo estacional sin redeploy
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCombo(int id, Combo combo)
        {
            if (id != combo.Id)
                return BadRequest(new { mensaje = "Id del combo no coincide" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comboExistente = await _context.Combos.FindAsync(id);
            if (comboExistente == null)
                return NotFound(new { mensaje = $"Combo con id {id} no encontrado" });

            // Actualiza propiedades básicas
            comboExistente.Nombre = combo.Nombre;
            comboExistente.Descripcion = combo.Descripcion;
            comboExistente.Precio = combo.Precio;

            // Si usas listas relacionadas (Tamales, Bebidas), deberás actualizar con lógica más específica.
            // Por simplicidad aquí no lo actualizo, pero puedes extender según tu diseño.

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/combos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCombo(int id)
        {
            var combo = await _context.Combos.FindAsync(id);
            if (combo == null)
                return NotFound(new { mensaje = $"Combo con id {id} no encontrado" });

            _context.Combos.Remove(combo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
