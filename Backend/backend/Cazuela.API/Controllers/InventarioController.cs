using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CazuelaChapina.Data;
using CazuelaChapina.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        #region Materias Primas CRUD

        [HttpGet("materias-primas")]
        public async Task<ActionResult<IEnumerable<MateriaPrima>>> GetMateriasPrimas()
            => await _context.MateriasPrimas.ToListAsync();

        [HttpPost("materias-primas")]
        public async Task<ActionResult<MateriaPrima>> CreateMateriaPrima(MateriaPrima materiaPrima)
        {
            _context.MateriasPrimas.Add(materiaPrima);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMateriasPrimas), new { id = materiaPrima.Id }, materiaPrima);
        }

        [HttpPut("materias-primas/{id}")]
        public async Task<IActionResult> UpdateMateriaPrima(int id, MateriaPrima materiaPrima)
        {
            if (id != materiaPrima.Id)
                return BadRequest("El ID de la URL no coincide con el del objeto enviado.");

            _context.Entry(materiaPrima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MateriaPrimaExists(id))
                    return NotFound($"No se encontró la materia prima con ID {id}.");
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

        private async Task<bool> MateriaPrimaExists(int id)
            => await _context.MateriasPrimas.AnyAsync(e => e.Id == id);

        #endregion

        #region Movimientos Inventario

        [HttpGet("movimientos")]
        public async Task<ActionResult<IEnumerable<InventarioMovimiento>>> GetMovimientos()
            => await _context.InventarioMovimientos
                .Include(m => m.MateriaPrima)
                .ToListAsync();

        [HttpPost("movimientos")]
        public async Task<ActionResult<InventarioMovimiento>> CreateMovimiento(InventarioMovimiento movimiento)
        {
            var materiaPrima = await _context.MateriasPrimas.FindAsync(movimiento.MateriaPrimaId);
            if (materiaPrima == null)
                return BadRequest("Materia prima no encontrada.");

            var validacion = ValidarMovimiento(movimiento, materiaPrima);
            if (validacion != null)
                return BadRequest(validacion);

            // Aplicar cambios de stock
            ActualizarStock(materiaPrima, movimiento);

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

            // Si se quiere revertir stock al eliminar, se haría aquí
            _context.InventarioMovimientos.Remove(movimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string ValidarMovimiento(InventarioMovimiento movimiento, MateriaPrima materiaPrima)
        {
            if (movimiento.Cantidad <= 0)
                return "La cantidad debe ser mayor que cero.";

            if (string.IsNullOrWhiteSpace(movimiento.TipoMovimiento))
                return "El tipo de movimiento es obligatorio.";

            var tipo = movimiento.TipoMovimiento.ToLower();
            if (tipo != "entrada" && tipo != "salida" && tipo != "merma")
                return "Tipo de movimiento inválido. Use 'Entrada', 'Salida' o 'Merma'.";

            if ((tipo == "salida" || tipo == "merma") && materiaPrima.CantidadDisponible < movimiento.Cantidad)
                return "No hay suficiente inventario para realizar la salida o merma.";

            return null;
        }

        private void ActualizarStock(MateriaPrima materiaPrima, InventarioMovimiento movimiento)
        {
            switch (movimiento.TipoMovimiento.ToLower())
            {
                case "entrada":
                    materiaPrima.CantidadDisponible += movimiento.Cantidad;
                    break;
                case "salida":
                case "merma":
                    materiaPrima.CantidadDisponible -= movimiento.Cantidad;
                    break;
            }

            _context.Entry(materiaPrima).State = EntityState.Modified;
        }

        #endregion
    }
}
